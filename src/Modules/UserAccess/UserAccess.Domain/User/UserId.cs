using Common.Domain;

namespace UserAccess.Domain.User;

public record UserId : EntityId
{
    public UserId(Guid value) : base(value)
    {
    }
}