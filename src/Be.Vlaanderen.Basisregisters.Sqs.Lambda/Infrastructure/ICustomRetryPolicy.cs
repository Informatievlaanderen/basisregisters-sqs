using System;
using System.Threading.Tasks;

namespace Be.Vlaanderen.Basisregisters.Sqs.Lambda.Infrastructure
{
    public interface ICustomRetryPolicy
    {
        Task Retry(Func<Task> functionToRetry);
    }
}
