namespace Web.Common.Data.Abstract;

public interface IWriteRepository<TEntity> : IRepository where TEntity : BaseEntity
{
    Task<TEntity> AddAsync(TEntity entity);
    
    Task<int> SaveChangesAsync();
}