using System.Data;
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
    Task UpdateUsersWithStoredProc(List<User> users);
}


public class UserService : IUserService
{
    private readonly AppDbContext _context;
    private readonly IConfiguration _configuration;
    public UserService(AppDbContext context,IConfiguration configuration)
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
    public async Task UpdateUsers(List<User> users)
    {
        _context.Users.UpdateRange(users);
        await _context.SaveChangesAsync();
    }
    public async Task UpdateUsersWithStoredProc(List<User> users)
{
    var table = new DataTable();
    table.Columns.Add("Id", typeof(int));
    table.Columns.Add("IsActive", typeof(bool));

    foreach (var user in users)
    {
        table.Rows.Add(user.Id, true);//user.IsActive);
    }

    var parameter = new SqlParameter("@Users", SqlDbType.Structured)
    {
        TypeName = "UsersTableType", 
        Value = table
    };
    await _context.Database.ExecuteSqlRawAsync("EXEC UpdateUsersBulk @Users", parameter);
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