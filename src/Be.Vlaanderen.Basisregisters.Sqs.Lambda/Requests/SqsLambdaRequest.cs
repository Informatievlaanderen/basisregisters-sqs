namespace Be.Vlaanderen.Basisregisters.Sqs.Lambda.Requests;

using System;
using System.Collections.Generic;
using GrAr.Provenance;
using MediatR;

public record SqsLambdaRequest(
    string MessageGroupId,
    Guid TicketId,
    string? IfMatchHeaderValue,
    Provenance Provenance,
    IDictionary<string, object?> Metadata) : IRequest;