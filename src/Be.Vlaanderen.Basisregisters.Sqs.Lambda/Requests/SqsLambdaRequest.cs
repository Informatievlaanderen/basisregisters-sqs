namespace Be.Vlaanderen.Basisregisters.Sqs.Lambda.Requests;

using System;
using System.Collections.Generic;
using GrAr.Provenance;
using MediatR;

public class SqsLambdaRequest : IRequest
{
    public Guid TicketId { get; set; }
    public string MessageGroupId { get; set; }
    public string? IfMatchHeaderValue { get; set; }
    public Provenance Provenance { get; set; }
    public IDictionary<string, object> Metadata { get; set; }
}