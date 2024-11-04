using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace App;

public interface IUserActivityService
{
    Task<IEnumerable<UserActivity>> GetUserActivitiesAsync();
    Task<UserActivity> GetUserActivityAsync(int id);
    Task<UserActivity> CreateUserActivityAsync(UserActivity userActivity);
    Task<UserActivity> UpdateUserActivityAsync(int id, UserActivity userActivity);
    Task DeleteUserActivityAsync(int id);
}
public class UserActivityService : IUserActivityService
{
    private readonly AppDbContext _context;

    public UserActivityService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<UserActivity>> GetUserActivitiesAsync()
    {
        return await _context.UserActivities.ToListAsync();
    }

    public async Task<UserActivity> GetUserActivityAsync(int id)
    {
        return await _context.UserActivities.FindAsync(id);
    }

    public async Task<UserActivity> CreateUserActivityAsync(UserActivity userActivity)
    {
        _context.UserActivities.Add(userActivity);
        await _context.SaveChangesAsync();
        return userActivity;
    }

    public async Task<UserActivity> UpdateUserActivityAsync(int id, UserActivity updatedUserActivity)
    {
        var existingActivity = await _context.UserActivities.FindAsync(id);
        if (existingActivity != null)
        {
            _context.Entry(existingActivity).CurrentValues.SetValues(updatedUserActivity);
            await _context.SaveChangesAsync();
        }
        return existingActivity;
    }

    public async Task DeleteUserActivityAsync(int id)
    {
        var userActivity = await _context.UserActivities.FindAsync(id);
        if (userActivity != null)
        {
            _context.UserActivities.Remove(userActivity);
            await _context.SaveChangesAsync();
        }
    }
}