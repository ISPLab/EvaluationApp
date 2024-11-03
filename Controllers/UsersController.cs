using Microsoft.AspNetCore.Mvc;

namespace App;

[ApiController]
[Route("api/[controller]")]
public class UsersController : ControllerBase
{
    private readonly IUserService _userService;

    public UsersController(IUserService userService)
    {
        _userService = userService;
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
}
