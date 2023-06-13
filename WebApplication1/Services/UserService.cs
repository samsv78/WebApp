using Microsoft.AspNetCore.Mvc;
using WebApplication1.Commands;
using WebApplication1.Helpers;
using WebApplication1.Models.DTOs;
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

    public async Task<List<UserInfo>> GetUser(long? id)
    {
        var userInfos = new List<UserInfo>();
        var users = new List<User>();
        if (id == null)
        {
            users = await _userRepository.GetAllUsers();
        }
        else
        {
            var user = await _userRepository.GetUserById(id.Value);
            if (user == null)
            {
                throw new Exception("Id " + id.Value + " not found in users.");
            }
            users.Add(user);
        }

        foreach (var user in users)
        {
            var userInfo = GetUserInfo(user);
            userInfos.Add(userInfo);
        }
        return userInfos;
    }

    private UserInfo GetUserInfo(User user)
    {
        var userInfo = new UserInfo
        {
            Id = user.Id,
            FirstName = user.FirstName,
            LastName = user.LastName,
            UserName = user.Username,
            RegisterDate = user.RegisterDate,
            UpdateDate = user.UpdateDate
        };
        return userInfo;
    }

    private async Task CheckUsernameAvailability(string username)
    {
        var user = await _userRepository.GetUserByUsername(username);
        if (user != null)
        {
            throw new Exception("Username already taken.");
        }
    }
}