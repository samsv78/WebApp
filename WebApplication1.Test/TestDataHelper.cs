using Microsoft.EntityFrameworkCore;
using Moq;
using Moq.EntityFrameworkCore;
using WebApplication1.Helpers;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entities;

namespace WebApplication1.Test;

public static class TestDataHelper
{
    public static Mock<DataContext> GetFakeContext()
    {
        var contextMock = new Mock<DataContext>();
        contextMock.Setup
        (
            x => x.User
        ).ReturnsDbSet(
            new List<User>()
            {
                new ("John", "Doe", "J1", CAes.Encrypt("1234"))
                {
                    Id = 1
                },
    
                new ("Jane", "Doe", "J2", CAes.Encrypt("4321"))
                {
                    Id = 2
                }
            }
        );
        return contextMock;
    }
    // public static DataContext GetFakeContext()
    // {
    //     var connectionString = "server=localhost; port=3306; database=test; user=root; password=Symbol123; Persist Security Info=False; Connect Timeout=300";
    //     var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
    //     optionsBuilder.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString));
    //     var dataContext = new DataContext(optionsBuilder.Options);
    //     return dataContext;
    // }
    // public static List<User> GetFakeUserList()
    // {
    //     return new List<User>()
    //     {
    // new User("John", "Doe", "J1", "1234")
    // {
    //     Id = 1
    // },
    //
    // new User("Jane", "Doe", "J2", "4321")
    // {
    //     Id = 2
    // }
    //     };
    // }
}