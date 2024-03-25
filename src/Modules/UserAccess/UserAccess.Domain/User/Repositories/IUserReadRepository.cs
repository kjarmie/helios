using System.Net.Mail;
using Common.Domain;
using Common.Utilities.FunctionalExtensions.ErrorHandling;

namespace UserAccess.Domain.User.Repositories;

public interface IUserReadRepository : IReadRepository<User, UserId>
{
    public Task<Result<User>> ReadByEmailAsync(MailAddress address, CancellationToken token = default);
    public Result<User> ReadByEmail(MailAddress address);
}