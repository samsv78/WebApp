namespace WebApplication1.Models.Entities;

public class User
{
    public User(string firstName, string lastName, string username, string password)
    {
        FirstName = firstName;
        LastName = lastName;
        Username = username;
        Password = password;
        RegisterDate = DateTime.Now;
        UpdateDate = RegisterDate;
    }
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Username { get; set; }
    public string Password { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime UpdateDate { get; set; }
}