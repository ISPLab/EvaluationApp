using Microsoft.AspNetCore.Mvc;

namespace App;

[ApiController]
[Route("api/[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserService _userService;

    public UserController(IUserService userService)
    {
        _userService = userService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<User>>> GetUsers()
    {
        var users = await _userService.GetUsers();
        return Ok(users);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<User>> GetUser(int id)
    {
        return await _userService.GetUser(id);
    }

    [HttpPost]
    public async Task<ActionResult<User>> CreateUser(User user)
    {
        return await _userService.CreateUser(user);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<User>> UpdateUser(int id, User user)
    {
        return await _userService.UpdateUser(id, user);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUser(int id)
    {
        await _userService.DeleteUser(id);
        return NoContent();
    }
}

[ApiController]
[Route("api/[controller]")]
public class UserActivityController : ControllerBase
{
    private readonly IUserActivityService _userActivityService;

    public UserActivityController(IUserActivityService userActivityService)
    {
        _userActivityService = userActivityService;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<UserActivity>>> GetUserActivities()
    {
        var res = await _userActivityService.GetUserActivitiesAsync();
        return Ok(res);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<UserActivity>> GetUserActivity(int id)
    {
        return await _userActivityService.GetUserActivityAsync(id);
    }

    [HttpPost]
    public async Task<ActionResult<UserActivity>> CreateUserActivity(UserActivity userActivity)
    {
        return await _userActivityService.CreateUserActivityAsync(userActivity);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult<UserActivity>> UpdateUserActivity(int id, UserActivity userActivity)
    {
        return await _userActivityService.UpdateUserActivityAsync(id, userActivity);
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteUserActivity(int id)
    {
        await _userActivityService.DeleteUserActivityAsync(id);
        return NoContent();
    }
}