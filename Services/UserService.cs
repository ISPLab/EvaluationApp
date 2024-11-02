using Microsoft.EntityFrameworkCore;

namespace App;


public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(int id, User user);
    Task DeleteUser(int id);
}


public class UserService : IUserService
{
    private readonly AppDbContext _context;

    public UserService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetUsers()
    {
        return await _context.Users.ToListAsync();
    }

    public async Task<User> GetUser(int id)
    {
        return await _context.Users.FindAsync(id);
    }

    public async Task<User> CreateUser(User user)
    {
        _context.Users.Add(user);
        await _context.SaveChangesAsync();
        return user;
    }

    public async Task<User> UpdateUser(int id, User user)
    {
        var existingUser = await _context.Users.FindAsync(id);
        if (existingUser != null)
        {
            _context.Entry(existingUser).CurrentValues.SetValues(user);
            await _context.SaveChangesAsync();
        }
        return existingUser;
    }

    public async Task DeleteUser(int id)
    {
        var user = await _context.Users.FindAsync(id);
        if (user != null)
        {
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }
    }
}