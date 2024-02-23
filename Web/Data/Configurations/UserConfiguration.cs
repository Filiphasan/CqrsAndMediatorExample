using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Web.Common.Data.Abstract;
using Web.Data.Entities;

namespace Web.Data.Configurations;

public class UserConfiguration : BaseConfiguration<User>
{
    protected override void ConfigureEntity(EntityTypeBuilder<User> builder)
    {
        builder.Property(x => x.FirstName)
            .IsRequired()
            .HasColumnName("FirstName")
            .HasMaxLength(50);

        builder.Property(x => x.LastName)
            .IsRequired()
            .HasColumnName("LastName")
            .HasMaxLength(50);

        builder.Property(x => x.Email)
            .IsRequired()
            .HasColumnName("Email")
            .HasMaxLength(256);
    }
}