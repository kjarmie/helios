using Common.Domain.ValueObjects;
using Common.Utilities.FunctionalExtensions.ErrorHandling;
using UserAccess.Application.Users.Login;

namespace UserAccess.Endpoints.Users.Login;

public static class LoginMapper
{
    public static Result<LoginCommand> Map(LoginRequest request)
    {
        LoginCommand command = new LoginCommand();
    }
}