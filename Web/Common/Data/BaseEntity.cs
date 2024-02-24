using NUlid;

namespace Web.Common.Data;

public abstract class BaseEntity
{
    public Ulid Id { get; set; } = Ulid.NewUlid();
}