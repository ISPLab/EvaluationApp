using Microsoft.AspNetCore.Mvc;

namespace App;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;
    private readonly IUserActivityService _userActivityService;
    private readonly IUserManager<User> _userManager;

    public UsersController(IUserService userService, IUserActivityService userActivityService, IUserManager<User> userManager)
    {
        _userService = userService;
        _userActivityService = userActivityService;
        _userManager = userManager;
    }

    [HttpPost]
    public async Task<ActionResult> UpdateUsers(List<UserDto> userDtos)
    {
        try
        {
            await _userService.UpdateUsersActivitiesWithStoredProc(userDtos);
            return Ok();
        }
        catch (Exception exception)
        {
            return StatusCode(500, $"Error updating users: {exception.Message}");
        }
    }


    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserDto>>> GetUsers()
    {
        try
        {

            var userIdHeader = HttpContext.Request.Headers["UserId"];
            if (int.TryParse(userIdHeader.FirstOrDefault(), out int userId))
            {
                var activity = await _userActivityService.GetUserActivityAsync(userId);
                if (activity.IsActive == false)
                    return new ForbidResult();
            }
            else
            {
                return new BadRequestResult();
            }

            var users = await _userService.GetUsers();
            var userActivities = await _userActivityService.GetUserActivitiesAsync();

            return Ok(users.Select(u => new UserDto
            {
                Id = u.Id,
                Username = u.Username,
                IsActive = userActivities.FirstOrDefault(a => a.UserId == u.Id)?.IsActive ?? false
            }));
        }
        catch (Exception ex)
        {
            return StatusCode(500, "Error getting users");
        }
    }
}
