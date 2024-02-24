using NUlid;

namespace Web.Common.Data.Abstract;

public interface IReadRepository<TEntity>
    : IRepository where TEntity : BaseEntity
{
    Task<TEntity?> GetByIdAsync(Ulid id);
}