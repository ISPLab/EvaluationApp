using System.Data;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace App;


public interface IUserService
{
    Task<IEnumerable<User>> GetUsers();
    Task<User> GetUser(int id);
    Task<User> CreateUser(User user);
    Task<User> UpdateUser(int id, User user);
    Task DeleteUser(int id);
    Task UpdateUsers(List<User> users);
    Task UpdateUsersActivitiesWithStoredProc(List<UserDto> users);
}


public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    public UserService(AppDbContext context, IConfiguration configuration)
    {
        _context = context;
        _configuration = configuration;
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

    public async Task UpdateUsersActivitiesWithStoredProc(List<UserDto> users)
    {
        var userTable = new DataTable
        {
            Columns =
            {
                { "Id", typeof(int) },
                { "IsActive", typeof(bool) }
            }
        };

        foreach (var user in users)
        {
            userTable.Rows.Add(user.Id, user.IsActive);
        }

        var userParameter = new SqlParameter("@Users", SqlDbType.Structured)
        {
            TypeName = "UsersTableType",
            Value = userTable
        };

        await _context.Database.ExecuteSqlRawAsync("EXEC UpdateUserActivitiesBulk @Users", userParameter);
    }
    
    public async Task UpdateUsers(List<User> users)
    {
        Console.WriteLine("Starting UpdateUsers method...");
        try
        {
            _context.Users.UpdateRange(users);
            Console.WriteLine("Users updated in context, saving changes...");
            await _context.SaveChangesAsync();
            Console.WriteLine("Users updated successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in UpdateUsers: {ex.Message}");
            throw;
        }
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