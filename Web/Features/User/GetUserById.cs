using MediatR;
using NUlid;
using Web.Common.Data.Abstract;

namespace Web.Features.User;

public static class GetUserById
{
    public class GetUserByIdQuery : IRequest<GetUserByIdResponse>
    {
        public required string Id { get; init; }
    }
    
    public class GetUserByIdResponse
    {
        public Data.Entities.User? User { get; set; }
    }
    
    public class GetUserByIdHandler(IReadRepository<Data.Entities.User> repository)
        : IRequestHandler<GetUserByIdQuery, GetUserByIdResponse>
    {
        public async Task<GetUserByIdResponse> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            if (!Ulid.TryParse(request.Id, out var ulid))
            {
                return new GetUserByIdResponse();
            }

            var user = await repository.GetByIdAsync(ulid);

            return new GetUserByIdResponse() { User = user };
        }
    }
}