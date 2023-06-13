using MediatR;
using WebApplication1.Commands;
using WebApplication1.Services;

namespace WebApplication1.Handlers;

public class CreateUserCommandHandler : AsyncRequestHandler<CreateUserCommand>
{
    private readonly IUserService _userService;

    public CreateUserCommandHandler(IUserService userService)
    {
        _userService = userService;
    }
    protected override async Task Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        await _userService.CreateUser(request);
    }
}