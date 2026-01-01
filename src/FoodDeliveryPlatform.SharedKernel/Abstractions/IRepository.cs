namespace FoodDeliveryPlatform.SharedKernel.Abstractions
{
    public interface IRepository<TEntity>
    {
        Task AddAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task<TEntity?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default);
        Task<IReadOnlyCollection<TEntity>> GetAllAsync(CancellationToken cancellationToken = default);
        Task UpdateAsync(TEntity entity, CancellationToken cancellationToken = default);
        Task DeleteAsync(TEntity entity, CancellationToken cancellationToken = default);
    }
}
