using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NUlid;

namespace Web.Common.Data.Abstract;

public abstract class BaseConfiguration<TEntity>
    : IEntityTypeConfiguration<TEntity> where TEntity : BaseEntity
{
    public void Configure(EntityTypeBuilder<TEntity> builder)
    {
        builder.HasKey(x => x.Id);
        builder.Property(x => x.Id)
            .ValueGeneratedNever()
            .HasColumnName("Id")
            .IsRequired()
            .HasConversion(ulid => ulid.ToString(),
                str => Ulid.Parse(str));
        
        ConfigureEntity(builder);
    }

    protected abstract void ConfigureEntity(EntityTypeBuilder<TEntity> builder);
}