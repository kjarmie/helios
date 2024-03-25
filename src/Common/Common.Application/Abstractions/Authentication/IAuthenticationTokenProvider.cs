using Common.Domain;
using Common.Utilities.FunctionalExtensions.ErrorHandling;

namespace Common.Application.Abstractions.Authentication;

public interface IAuthenticationTokenProvider<in TUserEntity> where TUserEntity : IUserEntity
{
    public Result<string> Generate(TUserEntity entity);
}