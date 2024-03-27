using Common.Application.Abstractions.Authentication;
using Common.Application.Abstractions.Messaging;
using Common.Utilities.FunctionalExtensions.ErrorHandling;
using UserAccess.Domain.User;
using UserAccess.Domain.User.Repositories;

namespace UserAccess.Application.Users.Login;

public sealed class LoginHandler : ICommandHandler<LoginCommand, LoginResult>
{
    private readonly IUserReadRepository _userReadRepository;
    private readonly IAuthenticationTokenProvider<User> _tokenProvider;

    public LoginHandler(IUserReadRepository userReadRepository, IAuthenticationTokenProvider<User> tokenProvider)
    {
        _userReadRepository = userReadRepository;
        _tokenProvider = tokenProvider;
    }

    public async Task<Result<LoginResult>> Handle(LoginCommand request, CancellationToken ct)
    {
        var user = (await _userReadRepository.ReadByEmailAsync(request.Email, ct))
            .Bind<string>(value => _tokenProvider.Generate(value))
            .Bind<LoginResult>(token => new LoginResult(token));

        return user;
    }
}