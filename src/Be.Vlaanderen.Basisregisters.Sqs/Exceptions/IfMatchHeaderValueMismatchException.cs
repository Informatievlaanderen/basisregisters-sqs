namespace Be.Vlaanderen.Basisregisters.Sqs.Exceptions;

using System;
using System.Runtime.Serialization;

[Serializable]
public sealed class IfMatchHeaderValueMismatchException : Exception
{
    public IfMatchHeaderValueMismatchException()
    { }

    public IfMatchHeaderValueMismatchException(string? message)
        : base(message)
    { }
}
