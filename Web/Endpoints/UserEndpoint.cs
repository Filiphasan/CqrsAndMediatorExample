using MediatR;
using Web.Features.User;

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

    private static async Task<IResult> AddUserAsync(AddUser.AddUserCommand request, ISender sender)
    {
        var user = await sender.Send(request);

        return Results.Ok(user);
    }

    private static async Task<IResult> GetUserByIdAsync(string id, ISender sender)
    {
        var user = await sender.Send(new GetUserById.GetUserByIdQuery(){ Id = id });
        return user.User is null
            ? Results.NotFound()
            : Results.Ok(user);
    }
}