using MediatR;

namespace WebApplication1.Commands;

public class UpdateUserCommand : IRequest
{
    public UpdateUserCommand(string firstName, string lastName, string oldUsername, string username, string oldPassword, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        OldUsername = oldUsername;
        Username = username;
        OldPassword = oldPassword;
        Password = password;
    }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string OldUsername { get; set; }
    public string Username { get; set; }
    public string OldPassword { get; set; }
    public string Password { get; set; }
}