namespace Be.Vlaanderen.Basisregisters.Sqs;

using System.Threading;
using System.Threading.Tasks;
using MessageHandling.AwsSqs.Simple;

public interface ISqsQueue
{
    Task<bool> Copy<T>(
        T message,
        SqsQueueOptions queueOptions,
        CancellationToken cancellationToken)
        where T : class;
}