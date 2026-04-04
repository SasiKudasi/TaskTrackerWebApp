using Identity.Application.Commands.LoginUser;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Shared;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("auth")]
    public class AuthController(ICommandHandler<LoginUserCommand> login) : ControllerBase
    {
        [HttpGet("login")]
        public async Task<IActionResult> Login([FromQuery] string userName, [FromQuery] string password, CancellationToken token)
        {
            var cmd = new LoginUserCommand(userName, password);
            var result = await login.HandleAsync(cmd, token);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }

            Response.Cookies.Append("token", result.Value.msg, new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = DateTimeOffset.UtcNow.AddHours(1)
            });
            return Ok("Success");

        }
    }
}
