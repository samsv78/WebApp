using MediatR;
using WebApplication1.Commands;
using WebApplication1.Services;

namespace WebApplication1.Handlers;

public class DeleteUserCommandHandler : AsyncRequestHandler<DeleteUserCommand>
{
    private readonly IUserService _userService;

    public DeleteUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }

    protected override async Task Handle(DeleteUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.DeleteUser(request);
    }
}