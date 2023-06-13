using MediatR;
using WebApplication1.Models.DTOs;
using WebApplication1.Queries;
using WebApplication1.Services;

namespace WebApplication1.Handlers;

public class GetUserQueryHandler : IRequestHandler<GetUserQuery, List<UserInfo>>
{
    private readonly IUserService _userService;

    public GetUserQueryHandler(IUserService userService)
    {
        _userService = userService;
    }

    public async Task<List<UserInfo>> Handle(GetUserQuery request, CancellationToken cancellationToken)
    {
        var users = await _userService.GetUser(request.Id);
        return users;
    }
}