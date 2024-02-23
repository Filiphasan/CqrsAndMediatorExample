using NUlid;
using Web.Common.Data;
using Web.Common.Data.Abstract;
using Web.Data.Context;

namespace Web.Data.Repositories;

public class ReadRepository<TEntity>(AppDbContextReadonly context)
    : IReadRepository<TEntity> where TEntity : BaseEntity
{
    public async Task<TEntity?> GetByIdAsync(Ulid id)
    {
        return await context.Set<TEntity>().FindAsync(id);
    }
}