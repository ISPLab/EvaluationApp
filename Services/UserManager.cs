using System.Security.Claims;
using App;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

public interface IUserManager<TUser> where TUser : class
{
    // Create a new user
    Task<IdentityResult> CreateAsync(TUser user, string password);

    // Update a user
    Task<IdentityResult> UpdateAsync(TUser user);

    // Delete a user
    Task<IdentityResult> DeleteAsync(TUser user);

    // Get a user by ID
    Task<TUser> FindByIdAsync(string userId);

    // Get a user by username
    Task<TUser> FindByNameAsync(string userName);

    // Get a user by email
    Task<TUser> FindByEmailAsync(string email);

    // Check if a user has a password
    Task<bool> HasPasswordAsync(TUser user);

    // Add a user to a role
    Task<IdentityResult> AddToRoleAsync(TUser user, string roleName);

    // Remove a user from a role
    Task<IdentityResult> RemoveFromRoleAsync(TUser user, string roleName);

    // Get the roles for a user
    Task<IList<string>> GetRolesAsync(TUser user);

    // Get the claims for a user
    Task<IList<Claim>> GetClaimsAsync(TUser user);

    // Add a claim to a user
    Task<IdentityResult> AddClaimAsync(TUser user, Claim claim);

    // Remove a claim from a user
    Task<IdentityResult> RemoveClaimAsync(TUser user, Claim claim);
    Task<bool> CheckPasswordAsync(User user, string password);
    Task<string> GenerateUserTokenAsync(User user, string v1, string v2);

}
public class UserManagerFake : IUserManager<User>
{
    private readonly AppDbContext _context;

    public UserManagerFake (AppDbContext context)
    {
        _context = context;
    }

    public Task<IdentityResult> AddClaimAsync(User user, Claim claim)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> AddToRoleAsync(User user, string roleName)
    {
        throw new NotImplementedException();
    }

 

    public Task<bool> CheckPasswordAsync(User user, string password)
    {
        if(password == "password")
        return Task.Run(() => true);
        else return Task.Run(() => false);
    }

    public Task<IdentityResult> CreateAsync(User user, string password)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> DeleteAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByEmailAsync(string email)
    {
        throw new NotImplementedException();
    }

    public Task<User> FindByIdAsync(string userId)
    {
        throw new NotImplementedException();
    }

    public async Task<User> FindByNameAsync(string userName)
    {
       return await _context.Users.FirstOrDefaultAsync(u => u.Username == userName);
    }

    public Task<string> GenerateUserTokenAsync(User user, string v1, string v2)
    {
        return Task.Run(() => Guid.NewGuid().ToString());
    }

    public Task<IList<Claim>> GetClaimsAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<IList<string>> GetRolesAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<bool> HasPasswordAsync(User user)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> RemoveClaimAsync(User user, Claim claim)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> RemoveFromRoleAsync(User user, string roleName)
    {
        throw new NotImplementedException();
    }

    public Task<IdentityResult> UpdateAsync(User user)
    {
        throw new NotImplementedException();
    }
}