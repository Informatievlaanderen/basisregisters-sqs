namespace Be.Vlaanderen.Basisregisters.Sqs.Lambda.Handlers;

using System.Threading;
using System.Threading.Tasks;
using AggregateSource;
using Exceptions;
using Infrastructure;
using MediatR;
using Requests;
using Responses;
using TicketingService.Abstractions;

public abstract class SqsLambdaHandlerBase<TSqsLambdaRequest> : IRequestHandler<TSqsLambdaRequest>
    where TSqsLambdaRequest : SqsLambdaRequest
{
    protected readonly ICustomRetryPolicy RetryPolicy;
    protected readonly ITicketing Ticketing;

    protected IIdempotentCommandHandler IdempotentCommandHandler { get; }

    protected SqsLambdaHandlerBase(
        ICustomRetryPolicy retryPolicy,
        ITicketing ticketing,
        IIdempotentCommandHandler idempotentCommandHandler)
    {
        RetryPolicy = retryPolicy;
        Ticketing = ticketing;
        IdempotentCommandHandler = idempotentCommandHandler;
    }

    protected abstract Task<ETagResponse> InnerHandle(TSqsLambdaRequest request, CancellationToken cancellationToken);

    protected abstract TicketError? MapDomainException(DomainException exception, TSqsLambdaRequest request);

    public async Task<Unit> Handle(TSqsLambdaRequest request, CancellationToken cancellationToken)
    {
        try
        {
            await ValidateIfMatchHeaderValue(request, cancellationToken);

            await Ticketing.Pending(request.TicketId, cancellationToken);

            ETagResponse? etag = null;

            await RetryPolicy.Retry(async () => etag = await InnerHandle(request, cancellationToken));

            await Ticketing.Complete(
                request.TicketId,
                new TicketResult(etag),
                cancellationToken);
        }
        catch (AggregateIdIsNotFoundException)
        {
            await HandleAggregateIdIsNotFoundException(request, cancellationToken);
        }
        catch (IfMatchHeaderValueMismatchException)
        {
            await Ticketing.Error(
                request.TicketId,
                new TicketError("Als de If-Match header niet overeenkomt met de laatste ETag.", "PreconditionFailed"),
                cancellationToken);
        }
        catch (DomainException exception)
        {
            var ticketError = MapDomainException(exception, request);
            ticketError ??= new TicketError(exception.Message, "");

            await Ticketing.Error(
                request.TicketId,
                ticketError,
                cancellationToken);
        }

        return Unit.Value;
    }

    protected abstract Task HandleAggregateIdIsNotFoundException(TSqsLambdaRequest request, CancellationToken cancellationToken);

    protected abstract Task ValidateIfMatchHeaderValue(TSqsLambdaRequest request, CancellationToken cancellationToken);
}