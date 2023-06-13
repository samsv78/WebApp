using MediatR;
using WebApplication1.Models.DTOs;

namespace WebApplication1.Commands;

public class CreateUserCommand : IRequest
{
    public CreateUserCommand(string firstName, string lastName, string userName, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        UserName = userName;
        Password = password;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public string Password { get; set; }
}