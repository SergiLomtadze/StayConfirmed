using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ActivateUserCommands;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ForgotPassowrdCommand;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ResetPasswordCommand;
using StayConfirmed.BusinessLogic.Commands.UserCommands.UserActivationCommand;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserQuery;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserStatusQuery;
using StayConfirmed.WebApi.Dto.UserDto;

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

        [HttpGet("ActivateUser/{Token}")]
        public async Task<ActionResult<string>> ActivateUser(string Token)
        {
            var result = await commandInvoker.Invoke(new ActivateUserCommandRequest
            {
                Token = Token
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

        [HttpPost("ForgotPassword")]
        public async Task<ActionResult<string>> ForgotPassword([FromBody] ForgotPasswordDto forgotPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await commandInvoker.Invoke(new ForgotPasswordCommandRequest
            {
                Email = forgotPassword.Email
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

        [HttpPost("ResetPassword")]
        public async Task<ActionResult<string>> ResetPassword([FromBody] ResetPasswordDto resetPassword)
        {
            if (!ModelState.IsValid)
                return BadRequest();

            var result = await commandInvoker.Invoke(new ResetPasswordCommandRequest
            {
                Token = resetPassword.Token,
                Password = resetPassword.Password
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
