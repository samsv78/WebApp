using Moq;
using WebApplication1.Commands;
using WebApplication1.Handlers;
using WebApplication1.Models.Context;
using WebApplication1.Controllers;
using WebApplication1.Models.Entities;
using WebApplication1.Queries;
using WebApplication1.Repositories;
using WebApplication1.Services;
using Xunit;
using Xunit.Abstractions;
using Xunit.Sdk;

namespace WebApplication1.Test;

public class UserHandlerAndServiceTests
{
    private readonly ITestOutputHelper _output;

    public UserHandlerAndServiceTests(ITestOutputHelper output)
    {
        _output = output;
    }
    private static Mock<DataContext> _contextMock = TestDataHelper.GetFakeContext();
    private static readonly IUserRepository UserRepositoryMock = new UserRepository(_contextMock.Object);
    private static readonly IUserService UserServiceMock = new UserService(UserRepositoryMock);
    
    [Fact]
    public async void GetUserQueryHandlerTest()
    {
        // Arrange
        var handlerMock = new GetUserQueryHandler(UserServiceMock);
        var request = new GetUserQuery(1);
        //Act
        var result = await handlerMock.Handle(request, CancellationToken.None);
        //Assert
        Assert.NotNull(result);
        Assert.Single(result);
        Assert.Equal(1, result[0].Id);
        _output.WriteLine("Test1 GetUserQueryHandlerTest Passed.");
    }
    
    [Fact]
    public async void DeleteUserServiceTest()
    {
        // Arrange
        var request = new DeleteUserCommand("J2", "4321");
        //Act
        await UserServiceMock.DeleteUser(request);
        //Assert
        var a = _contextMock.Object.User.Count();
        _output.WriteLine("Test2 DeleteUserServiceTest Passed.");
    }
    
    [Fact]
    public async void CreateUserServiceTest()
    {
        // Arrange
        var request = new CreateUserCommand("John", "Doe", "J3", "1234");
        //Act
        await UserServiceMock.CreateUser(request);
        //Assert
        
        _output.WriteLine("Test2 DeleteUserServiceTest Passed.");
    }
    
    [Fact]
    public async void UpdateUserServiceTest()
    {
        // Arrange
        var request = new UpdateUserCommand("John", "Doe", "J1",
            "J4","1234","4321");
        //Act
        await UserServiceMock.UpdateUser(request);
        //Assert
        var a = _contextMock.Object.User.Count();
        _output.WriteLine("Test2 DeleteUserServiceTest Passed.");
    }
    
    

    
}