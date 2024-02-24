using MediatR;
using Web.Common.Data.Abstract;

namespace Web.Features.User;

public static class AddUser
{
    public class AddUserCommand : IRequest<AddUserResponse>
    {
        public string FirstName { get; init; } = null!;
        public string LastName { get; init; } = null!;
        public string Email { get; init; } = null!;
    }

    public class AddUserResponse
    {
        public Data.Entities.User? User { get; set; }
    }

    public sealed class AddUserHandler(IWriteRepository<Data.Entities.User> repository)
        : IRequestHandler<AddUserCommand, AddUserResponse>
    {
        public async Task<AddUserResponse> Handle(AddUserCommand request, CancellationToken cancellationToken)
        {
            var user = new Data.Entities.User
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email
            };

            await repository.AddAsync(user);
            await repository.SaveChangesAsync();

            return new AddUserResponse() { User = user };
        }
    }
}