using Common.Domain.Abstractions;
using Common.Utilities.FunctionalExtensions.ErrorHandling;
using Common.Utilities.Utilities;

namespace Common.Domain.ValueObjects;

public record Name : IValueObject<string, Name>
{
    public string Value { get; }

    private Name(string value)
    {
        Value = value;
    }

    private static Result<string> Validate(string value) =>
        !string.IsNullOrWhiteSpace(value)
            ? value
            : Error.New("ValueObject.Name.EmptyOrNull", "Name should not be null empty.");


    public static Name Parse(string value)
    {
        return new Name(value);
    }

    public static Result<Name> Create(string value) =>
        Validate(value)
            .Bind<Name>(v => new Name(v));

    public static bool IsValid(string value)
    {
        return !string.IsNullOrWhiteSpace(value);
    }
}