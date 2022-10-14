using System.Collections.Generic;
using System.Collections.Immutable;

namespace Be.Vlaanderen.Basisregisters.Sqs.Lambda.Infrastructure
{
    public static class TransientSqlErrors
    {
        public static ImmutableList<int> Errors { get; } = new List<int> { 926, 4060, 40197, 40501, 40549, 40550, 40613, 49918, 49919, 49920, 4221, 615 }.ToImmutableList();
    }
}
