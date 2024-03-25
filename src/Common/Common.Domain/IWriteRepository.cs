using Common.Domain.Abstractions;

namespace Common.Domain;

public interface IWriteRepository<TEntity, TEntityId> where TEntity : IEntity where TEntityId : EntityId
{
}