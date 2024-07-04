using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ActivateUserCommands;
using StayConfirmed.BusinessLogic.Commands.UserCommands.UserActivationCommand;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserQuery;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserStatusQuery;

namespace StayConfirmed.WebApi.Controllers.User
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(CommandInvoker commandInvoker) : ControllerBase
    {
        [HttpGet("GetUserSecret")]
        public async Task<ActionResult<string>> GetUserSecret(string email)
        {
            var userStatusResponse = await commandInvoker.Invoke(new GetUserStatusQueryRequest());
            if (!userStatusResponse.IsActive)
            {
                return BadRequest("User Not Active");
            }


            var result = await commandInvoker.Invoke(new GetUserQueryRequest 
            {
                Email = email
            });
            return Ok(result.UserModel.Secret);
        }

        [HttpPost("RequestUserActivation")]
        [Authorize]
        public async Task<ActionResult<string>> RequestUserActivation(string email)
        {
            var result = await commandInvoker.Invoke(new UserActivationCommandRequest
            {
                Email = email
            });

            if (result.Status)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }

        [HttpPost("ActivateUser")]
        public async Task<ActionResult<string>> ActivateUser(string token)
        {
            var result = await commandInvoker.Invoke(new ActivateUserCommandRequest
            {
                Token = token
            });

            if (result.Status)
            {
                return Ok(result.Message);
            }
            else
            {
                return BadRequest(result.Message);
            }
        }
    }
}
