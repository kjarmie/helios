using Common.Domain.ValueObjects;
using FastEndpoints;
using MediatR;
using UserAccess.Application.Users.Login;

namespace UserAccess.Endpoints.Users.Login;

public class LoginEndpoint : Endpoint<LoginRequest, LoginResponse>
{
    private readonly IMediator _mediator;

    public LoginEndpoint(IMediator mediator)
    {
        _mediator = mediator;
    }

    public override async Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        var command = LoginMapper.Map(req);

        command.BindAsync<LoginResult>(
            async (c) => await _mediator.Send(c, ct)
        );

        command.Match(
            ok => ,
            fail => ,
        );

        // var email = Email.Create(req.Email);
        // var password = Password.Create(req.Password);

        LoginCommand command = new(Email.Parse(req.Email), Password.Parse(req.Password));

        var loginResult = await _mediator.Send(command, ct);
    }
}