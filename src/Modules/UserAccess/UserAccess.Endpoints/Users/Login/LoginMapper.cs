using Common.Domain.ValueObjects;
using Common.Utilities.FunctionalExtensions.ErrorHandling;
using UserAccess.Application.Users.Login;

namespace UserAccess.Endpoints.Users.Login;

public static class LoginMapper
{
    public static Result<LoginCommand> Map(LoginRequest request)
    {
        var command = new LoginCommand();

        return Email.Create(request.Email)
            .Bind(e =>
            {
                command.Email = e;
                return Password.Create(request.Password);
            })
            .Map(p =>
            {
                command.Password = p;
                return command;
            });
    }
}