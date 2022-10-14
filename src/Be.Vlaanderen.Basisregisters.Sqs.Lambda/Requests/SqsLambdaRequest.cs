using System;
using Be.Vlaanderen.Basisregisters.GrAr.Provenance;
using MediatR;

namespace Be.Vlaanderen.Basisregisters.Sqs.Lambda.Requests
{
    using System.Collections.Generic;

    public class SqsLambdaRequest : IRequest
    {
        public Guid TicketId { get; set; }
        public string MessageGroupId { get; set; }
        public string? IfMatchHeaderValue { get; set; }
        public Provenance Provenance { get; set; }
        public IDictionary<string, object> Metadata { get; set; }
    }
}
