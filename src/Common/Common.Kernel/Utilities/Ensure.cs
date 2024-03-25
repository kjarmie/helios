using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace Common.Utilities.Utilities;

public static class Ensure
{
    public static void IsNotNullOrEmpty([NotNull] string value,
        [CallerArgumentExpression("value")] string? paramName = null)
    {
        if (string.IsNullOrEmpty(value))
            throw new ArgumentException(paramName);
    }
}