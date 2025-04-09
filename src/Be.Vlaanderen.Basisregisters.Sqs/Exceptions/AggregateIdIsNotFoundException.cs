namespace Be.Vlaanderen.Basisregisters.Sqs.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public sealed class AggregateIdIsNotFoundException : Exception
{
    public AggregateIdIsNotFoundException()
    { }

    public AggregateIdIsNotFoundException(string? message)
        : base(message)
    { }
}
