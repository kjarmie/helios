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

    public override Task HandleAsync(LoginRequest req, CancellationToken ct)
    {
        LoginCommand command = new(Email.Create(req.Email), Password.Create(req.Password));

        var loginResult = _mediator.Send()
    }
}