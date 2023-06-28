using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Commands;
using WebApplication1.Helpers;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entities;
using WebApplication1.Queries;
using WebApplication1.Repositories;
using WebApplication1.Services;
using Xunit;

namespace WebApplication1.Test.UnitTest;

public class UserCrudTest
{
    private static readonly DataContext Context = GetInMemoryDbContext();
    private static readonly IUserRepository UserRepository = new UserRepository(Context);
    private static readonly IUserService UserService = new UserService(UserRepository);
    private static readonly bool SeedSuccess = SeedData(Context);
    [Fact]
    public async void CreateUserServiceTest()
    {
        // Arrange
        var request = new CreateUserCommand("John", "Doe", "J3", "1234");
        //Act
        await UserService.CreateUser(request);
        //Assert
        var user = await UserRepository.GetUserByUsername("J3");
        Assert.NotNull(user);
    }
    
    [Fact]
    public async void DeleteUserServiceTest()
    {
        // Arrange
        var request = new DeleteUserCommand("J1", "123456");
        var a = Context.User;
        //Act
        await UserService.DeleteUser(request);
        //Assert
        var user = await UserRepository.GetUserByUsername("J1");
        Assert.Null(user);
    }
    
    
    [Fact]
    public async void UpdateUserServiceTest()
    {
        // Arrange
        var request = new UpdateUserCommand("John", "Doe", "J2",
            "J4", "123456", "4321");
        //Act
        await UserService.UpdateUser(request);
        //Assert
        var user = await UserRepository.GetUserByUsername("J4");
        Assert.NotNull(user);
    }
    
    [Fact]
    public async void GetUserQueryServiceTest()
    {
        //Arrange
        var request = new GetUserQuery(null);
        //Act
        var result = await UserService.GetUser(request.Id);
        //Assert
        Assert.NotNull(result);
    }

    private static DataContext GetInMemoryDbContext()
    {
        var optionsBuilder = new DbContextOptionsBuilder<DataContext>();
        optionsBuilder.UseInMemoryDatabase(databaseName: "TestDb");
        var dataContext = new DataContext(optionsBuilder.Options);
        return dataContext;
    }

    private static bool SeedData(DataContext context)
    {
        if (context.User.Count() != 0)
        {
            return false;
        }
        var user = new User("J", "D", "J1", CAes.Encrypt("123456"));
        var user2 = new User("J", "D", "J2", CAes.Encrypt("123456"));
        var users = new List<User> { user, user2 };
        context.AddRange(users);
        context.SaveChanges();
        return true;
    }
    
}