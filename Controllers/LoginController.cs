using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using System.Threading.Tasks;
using App;

namespace MyApplication.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {

        private readonly IUserManager<User> _userManager;
        private readonly IUserActivityService _userActivityService;

        public LoginController(IUserManager<User> userManager, IUserActivityService userActivityService)
        {
            _userManager = userManager;
            _userActivityService = userActivityService;
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginModel model)
        {
            Console.WriteLine("LoginController: Login called.");

            if (!ModelState.IsValid)
            {
                Console.WriteLine("LoginController: Login: ModelState is invalid.");
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null)
            {
                Console.WriteLine("LoginController: Login: User not found.");
                return NotFound("User not found");
            }

            var passwordValid = await _userManager.CheckPasswordAsync(user, model.Password);
            if (!passwordValid)
            {
                Console.WriteLine("LoginController: Login: Invalid password.");
                return Unauthorized("Invalid password");
            }

            Console.WriteLine("LoginController: Login: Password is valid. Generating token.");
            var token = await _userManager.GenerateUserTokenAsync(user, "Default", "access_token");

            Console.WriteLine("LoginController: Login: Got token. Getting user activity.");
            var activity = await _userActivityService.GetUserActivityAsync(user.Id);
            Console.WriteLine("LoginController: Login: Got user activity.");

            Console.WriteLine("LoginController: Login: Creating user DTO.");
            // var userDTO = toUserDTO(user,activity,token);
            var userDTO = new UserDto{
                Id = user.Id,
                Username = user.Username,
                IsActive = activity.IsActive,
                Token = token
            };

            Console.WriteLine("LoginController: Login: Returning user DTO.");
            return Ok( userDTO );
        }

        [HttpPost("logout")]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync();
            return Ok();
        }

        // public UserDto toUserDTO(User user, UserActivity activity, string token)
        // {
        //     return new UserDto{
        //         Id = user.Id,
        //         Username = user.Username,
        //         IsActive = activity.IsActive,
        //         Token = token
        //     };
        // }

    }

}