using MediatR;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Queries;

public class GetUserQuery : IRequest<List<UserInfo>>
{
    public GetUserQuery(long? id)
    {
        Id = id;
    }
    public long? Id { get; set; }
}