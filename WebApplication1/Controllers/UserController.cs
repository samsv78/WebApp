using MediatR;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Commands;
using WebApplication1.Models.DTOs;
using WebApplication1.Queries;

namespace WebApplication1.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IMediator _mediator;
    public UserController(IMediator mediator)
    {
        _mediator = mediator;
    }
    [HttpPost("CreateUser")]
    public async Task<IActionResult> CreateUser(CreateUserRequest createUserRequest)
    {
        var command = new CreateUserCommand
        (
            createUserRequest.FirstName,
            createUserRequest.LastName,
            createUserRequest.UserName,
            createUserRequest.Password
        );
        await _mediator.Send(command);
        return Ok();
    }
    [HttpGet("GetUser")]
    public async Task<IActionResult> CreateUser(long? id)
    {
        var query = new GetUserQuery(id);
        var res = await _mediator.Send(query);
        return Ok(res);
    }
    
    [HttpDelete("DeleteUser")]
    public async Task<IActionResult> DeleteUser(DeleteUserRequest deleteUserRequest)
    {
        var command = new DeleteUserCommand
            (
                deleteUserRequest.Username,
                deleteUserRequest.Password
            );
        await _mediator.Send(command);
        return Ok();
    }

}