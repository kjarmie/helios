using System.Text.RegularExpressions;
using Common.Domain.Abstractions;
using Common.Utilities.FunctionalExtensions.ErrorHandling;

namespace Common.Domain.ValueObjects;

public class Email : IValueObject<string, Email>
{
    private Email(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Email Parse(string value) => new(value);

    public static Result<Email> Create(string value) =>
        Validate(value)
            .Bind<Email>(v => new Email(v));

    public static bool IsValid(string value)
    {
        return !Validate(value).IsError;
    }

    private static Result<string> Validate(string value)
    {
        var pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$";

        var regex = new Regex(pattern);

        if (!regex.IsMatch(value))
            return Error.New("ValueObject.Email.InvalidEmailAddress", "Email address is not valid");

        return value;
    }

    public static implicit operator Email?(string email)
    {
        var result = Validate(email);
        return result.Match<Email?>(ok => new Email(ok), fail => null);
    }
}