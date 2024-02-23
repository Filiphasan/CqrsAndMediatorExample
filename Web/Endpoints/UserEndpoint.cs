using NUlid;
using Web.Common.Data.Abstract;
using Web.Data.Entities;

namespace Web.Endpoints;

public class UserEndpoint : BaseEndpoint
{
    public override void AddRoutes(IEndpointRouteBuilder app)
    {
        var group = app.MapGroup("/api/users")
            .WithGroupName("Users");

        group.MapPost("", AddUserAsync);
        group.MapGet("/{id}", GetUserByIdAsync);
    }

    private static async Task<IResult> AddUserAsync(UserRequest request, IWriteRepository<User> repository)
    {
        var user = new User
        {
            FirstName = request.FirstName,
            LastName = request.LastName,
            Email = request.Email
        };

        await repository.AddAsync(user);
        await repository.SaveChangesAsync();

        return Results.Ok(user);
    }

    private static async Task<IResult> GetUserByIdAsync(string id, IReadRepository<User> repository)
    {
        if (!Ulid.TryParse(id, out var ulid))
        {
            return Results.BadRequest();
        }

        var user = await repository.GetByIdAsync(ulid);
        return user is null
            ? Results.NotFound()
            : Results.Ok(user);
    }
}

public record UserRequest
{
    public string FirstName { get; init; } = null!;
    public string LastName { get; init; } = null!;
    public string Email { get; init; } = null!;
}