using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Be.Vlaanderen.Basisregisters.Sqs.Lambda.Handlers
{
    public interface IIdempotentCommandHandler
    {
        Task<long> Dispatch(
            Guid? commandId,
            object command,
            IDictionary<string, object> metadata,
            CancellationToken cancellationToken);
    }
}
