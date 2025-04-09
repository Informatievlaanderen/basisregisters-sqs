namespace Be.Vlaanderen.Basisregisters.Sqs.Requests;

using System;
using System.Collections.Generic;
using GrAr.Provenance;
using MediatR;

public class SqsRequest : IRequest<LocationResult>
{
    public Guid TicketId { get; set; }
    public string? IfMatchHeaderValue { get; set; }
    public required ProvenanceData ProvenanceData { get; set; }
    public IDictionary<string, object?> Metadata { get; set; } = new Dictionary<string, object?>();
}
