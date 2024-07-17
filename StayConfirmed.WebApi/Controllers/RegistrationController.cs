using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.WebApi.Dto.Registration;
using StayConfirmed.BusinessLogic.Commands.RegistrationCommands.RegisterCommand;

namespace StayConfirmed.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RegistrationController(UserManager<DataAccess.Entities.User> userManager,
        CommandInvoker commandInvoker) : ControllerBase
    {
        [HttpPost("Register")]
        public async Task<ActionResult<string>> Register([FromBody] RegisterDto register)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stakeholderResult = await commandInvoker.Invoke(new RegisterStakeholderCommandRequest
            {
                StakeholderName = register.CompanyName,
                Vat = register.Vat,
                Phone = register.Phone,
                StakeholderEmail = register.CompanyEmail,
                Address = register.Address,
                City = register.City,
                Zip = register.Zip,
                Region = register.Region,
                Province = register.Province,
            });

            if (!stakeholderResult.Status)
            {
                return BadRequest(stakeholderResult.Message);
            }

            var user = new DataAccess.Entities.User
            {
                UserName = register.UserEmail,
                Email = register.UserEmail,
                IdStakeholder = stakeholderResult.Stakeholder.IdStakeholder,
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (result.Succeeded)
            {
                return Ok("Registration successful");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return BadRequest(ModelState);
        }
    }
}
