using System.Text.RegularExpressions;
using Common.Domain.Abstractions;
using Common.Utilities.FunctionalExtensions.ErrorHandling;

namespace Common.Domain.ValueObjects;

public record Password : IValueObject<string, Password>
{
    private Password(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Password Parse(string value) => new(value);

    public static Result<Password> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Error.New("ValueObject.Password.EmptyOrNull", "Password should not be null empty.");

        var hasNumber = new Regex(@"[0-9]+");
        var hasUpperChar = new Regex(@"[A-Z]+");
        var hasMinChars = new Regex(@".{8}");
        var hasLowerChar = new Regex(@"[a-z]+");
        var hasSymbols = new Regex(@"[!@#$%^&*()_+=\[{\]};:<>|./?,-]");

        if (!hasLowerChar.IsMatch(value))
            return Error.New("ValueObject.Password.NoLowerChar", "Password should contain at least one lower case letter.");
        if (!hasUpperChar.IsMatch(value))
            return Error.New("ValueObject.Password.NoUpperChar", "Password should contain at least one upper case letter.");
        if (!hasMinChars.IsMatch(value))
            return Error.New("ValueObject.Password.MinChars", "Password should not be less than or greater than 12 characters.");
        if (!hasNumber.IsMatch(value))
            return Error.New("ValueObject.Password.NoNumber", "Password should contain at least one numeric value.");
        if (!hasSymbols.IsMatch(value))
            return Error.New("ValueObject.Password.NoSymbols", "Password should contain at least one special case characters.");

        return new Password(value);
    }

    public static implicit operator string(Password password) => password.Value;
}