namespace WebApplication1.Models.DTOs;

public class UpdateUserRequest
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string OldUserName { get; set; }
    public string Username { get; set; }
    public string OldPassword { get; set; }
    public string Password { get; set; }
}