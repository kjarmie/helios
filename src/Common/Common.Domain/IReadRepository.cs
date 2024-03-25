using Common.Domain.Abstractions;
using Common.Utilities.FunctionalExtensions.ErrorHandling;

namespace Common.Domain;

public interface IReadRepository<TEntity, TEntityId> where TEntity : IEntity where TEntityId : EntityId
{
    public Task<Result<TEntity>> ReadSingleAsync(EntityId id, CancellationToken token = default);
    public Result<TEntity> ReadSingle(EntityId id);

    public Task<Result<List<TEntity>>> ReadAllAsync(CancellationToken token = default);
    public Result<List<TEntity>> ReadAll();

    public Task<Result<List<TEntity>>> ReadSpecificAsync(List<EntityId> ids, CancellationToken token = default);
    public Result<List<TEntity>> ReadSpecific(List<EntityId> ids);

    public Task<Result<T>> ReadFilteredAsync<T>(Func<IEnumerable<TEntity>, Task<T>> filters,
        CancellationToken token = default);

    public Result<T> ReadFiltered<T>(List<EntityId> ids);
}