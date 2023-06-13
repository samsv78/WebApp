namespace WebApplication1.Models.DTOs;

public class UserInfo
{
    public long Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string UserName { get; set; }
    public DateTime RegisterDate { get; set; }
    public DateTime UpdateDate { get; set; }
}