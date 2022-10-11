namespace Be.Vlaanderen.Basisregisters.Sqs;

using System.Threading;
using System.Threading.Tasks;
using MessageHandling.AwsSqs.Simple;
using SqsHelper = MessageHandling.AwsSqs.Simple.Sqs;

public sealed class SqsQueue : ISqsQueue
{
    private readonly SqsOptions _sqsOptions;
    private readonly string _queueUrl;

    public SqsQueue(SqsOptions sqsOptions, string queueUrl)
    {
        _sqsOptions = sqsOptions;
        _queueUrl = queueUrl;
    }

    public async Task<bool> Copy<T>(T message, SqsQueueOptions queueOptions, CancellationToken cancellationToken)
        where T : class
    {
        return await SqsHelper.CopyToQueue(_sqsOptions, _queueUrl, message, queueOptions, cancellationToken);
    }
}