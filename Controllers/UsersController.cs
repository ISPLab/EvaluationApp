using Microsoft.AspNetCore.Mvc;

namespace App;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUserActivityService _userActivityService;

    public UsersController(IUserService userService, IUserActivityService userActivityService)
    {
        _userService = userService;
        _userActivityService = userActivityService;
    }

    [HttpPost]
    public async Task<ActionResult> UpdateUsers(List<User> users)
    {
        var userString = string.Join(", ", users.Select(u => u.Username));
        Console.WriteLine("Updating users..." + userString);
        try
        {
            await _userService.UpdateUsersWithStoredProc(users);
            Console.WriteLine("Users updated successfully");
            return Ok();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error updating users: {ex.Message}");
            return StatusCode(500, "Error updating users");
        }
    }


    [HttpGet]
    public async Task<ActionResult> GetUsers()
    {
        Console.WriteLine("Getting users...");
        try
        {
            var users = await _userService.GetUsers();
            Console.WriteLine($"Got {users.Count()} users.");

            var activities = await _userActivityService.GetUserActivitiesAsync();
            Console.WriteLine($"Got {activities.Count()} user activities.");

            var userDtos = users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                IsActive = activities.Any(a => a.UserId == u.Id)
            }).ToList();

            Console.WriteLine("get user successfully");
            return Ok(userDtos);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error getting users: {ex.Message}");
            return StatusCode(500, "Error getting users");
        }
    }
}
