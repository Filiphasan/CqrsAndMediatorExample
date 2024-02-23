using NUlid;

namespace Web.Common.Data;

public class BaseEntity
{
    public Ulid Id { get; set; } = Ulid.NewUlid();
}