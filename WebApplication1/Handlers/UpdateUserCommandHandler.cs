using MediatR;
using WebApplication1.Commands;
using WebApplication1.Services;

namespace WebApplication1.Handlers;

public class UpdateUserCommandHandler : AsyncRequestHandler<UpdateUserCommand>
{
    private readonly IUserService _userService;

    public UpdateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    protected override async Task Handle(UpdateUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.UpdateUser(request);
    }
}