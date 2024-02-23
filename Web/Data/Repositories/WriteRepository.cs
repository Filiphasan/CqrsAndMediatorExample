using Web.Common.Data;
using Web.Common.Data.Abstract;
using Web.Data.Context;

namespace Web.Data.Repositories;

public class WriteRepository<TEntity>(AppDbContext context) : IWriteRepository<TEntity> where TEntity : BaseEntity
{
    public async Task<TEntity> AddAsync(TEntity entity)
    {
        await context.Set<TEntity>().AddAsync(entity);
        return entity;
    }

    public async Task<int> SaveChangesAsync()
    {
        return await context.SaveChangesAsync();
    }
}