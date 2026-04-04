using Identity.Api.Contracts;
using Identity.Application.Commands.CreateUser;
using Identity.Application.Queries.GetUsers;
using Identity.Domain;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Task.Application.Shared;

namespace Identity.Api.Controllers
{
    [ApiController]
    [Route("users")]
    public class UserController(ICommandHandler<CreateUserCommand> createUserCommand,
        IQueryHandler<GetUsersQuery, List<User>> getUsersQuery) : ControllerBase
    {
        [HttpGet]
        [Authorize ("Admin")]
        public async Task<ActionResult<List<User>>> GetUsers(CancellationToken token)
        {
            var result = await getUsersQuery.HandleAsync(new GetUsersQuery(), token);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }

        [HttpPost]
        public async Task<ActionResult> CreateUser([FromBody] CreateUserRequest request, CancellationToken token)
        {
            var cmd = new CreateUserCommand(request.UserName, request.Password, request.Role);
            var result = await createUserCommand.HandleAsync(cmd, token);
            if (result.IsFailure)
            {
                return BadRequest(result.Error);
            }
            return Ok(result.Value);
        }



    }
}
