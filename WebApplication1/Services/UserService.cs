using Microsoft.AspNetCore.Mvc;
using WebApplication1.Commands;
using WebApplication1.Helpers;
using WebApplication1.Models.Entities;
using WebApplication1.Repositories;

namespace WebApplication1.Services;

public class UserService : IUserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public async Task CreateUser(CreateUserCommand request)
    {
        await CheckUsernameAvailability(request.UserName);
        var user = new User(
            request.FirstName,
            request.LastName,
            request.UserName,
            AES.Encrypt(request.Password)
        );
        await _userRepository.CreateUser(user);
    }

    private async Task CheckUsernameAvailability(string username)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user != null)
        {
            throw new Exception("Username Already Taken.");
        }
    }
}