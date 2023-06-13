using Microsoft.AspNetCore.Mvc;
using WebApplication1.Commands;

namespace WebApplication1.Services;

public interface IUserService
{
    Task CreateUser(CreateUserCommand request);
}