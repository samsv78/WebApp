using Microsoft.EntityFrameworkCore;
using WebApplication1.Models.Context;
using WebApplication1.Models.Entities;

namespace WebApplication1.Repositories;

public class UserRepository : IUserRepository
{
    private readonly DataContext _context;

    public UserRepository(DataContext context)
    {
        _context = context;
    }

    public async Task<User> GetUserByUsername(string username)
    {
        var user = await _context.User.FirstOrDefaultAsync(p => p.Username == username);
        return user;
    }

    public async Task CreateUser(User user)
    {
        await _context.User.AddAsync(user);
        await _context.SaveChangesAsync();
    }

    public async Task<List<User>> GetAllUsers()
    {
        var users = await _context.User.ToListAsync();
        return users;
    }

    public async Task<User> GetUserById(long id)
    {
        var user = await _context.User.FirstOrDefaultAsync(p => p.Id == id);
        return user;
    }

    public async Task DeleteUser(User user)
    {
        _context.User.Remove(user);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateUser(User user)
    {
        _context.User.Update(user);
        await _context.SaveChangesAsync();
    }
}