using Microsoft.EntityFrameworkCore;

namespace Web.Data.Context;

public class AppDbContextReadonly(DbContextOptions options) : AppDbContext(options)
{
    public override int SaveChanges()
    {
        throw new InvalidOperationException("Readonly context. Use AppDbContext instead.");
    }

    public override int SaveChanges(bool acceptAllChangesOnSuccess)
    {
        throw new InvalidOperationException("Readonly context. Use AppDbContext instead.");
    }

    public override Task<int> SaveChangesAsync(bool acceptAllChangesOnSuccess, CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Readonly context. Use AppDbContext instead.");
    }

    public override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
    {
        throw new InvalidOperationException("Readonly context. Use AppDbContext instead.");
    }
}