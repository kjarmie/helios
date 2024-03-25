using Common.Domain.Abstractions;
using Common.Utilities.Utilities;

namespace Common.Domain.ValueObjects;

public record struct Name : IValueObject
{
    public string Value { get; }

    public Name(string value)
    {
        Ensure.IsNotNullOrEmpty(value);
        Value = value;
    }

    public bool Validate()
    {
        return string.IsNullOrWhiteSpace(Value);
    }
}