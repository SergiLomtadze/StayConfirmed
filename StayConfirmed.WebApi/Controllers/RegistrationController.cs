﻿using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.WebApi.Dto.Registration;
using StayConfirmed.BusinessLogic.Commands.RegistrationCommands.RegisterCommand;
using StayConfirmed.BusinessLogic.Commands.StakeholderCommands.DeleteStakeholderCommand;
using System.Text;
using DocumentFormat.OpenXml.Office2010.Excel;
using StayConfirmed.BusinessLogic.Queries.StakeholderQueries.GetAllStakeholdersQuery;

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
                return BadRequest(stakeholderResult);
            }

            var user = new DataAccess.Entities.User
            {
                UserName = register.UserEmail,
                Email = register.UserEmail,
                IdStakeholder = stakeholderResult.Stakeholder.IdStakeholder,
                Name = register.UserName,
                Surname = register.UserSurname
            };

            var result = await userManager.CreateAsync(user, register.Password);

            if (!result.Succeeded)
            {
                StringBuilder errors = new();
                foreach (var error in result.Errors)
                {
                    errors.AppendLine(error.Description);
                }
                var stakeholderDeleteResult = await commandInvoker.Invoke(new DeleteStakeholderCommandRequest
                {
                    Vat = register.Vat,
                });
                if (!stakeholderDeleteResult.Status)
                {
                    errors.AppendLine(stakeholderDeleteResult.Message);
                }
                return BadRequest(new RegisterStakeholderCommandResponse
                {
                    Status = false,
                    Message = errors.ToString(),
                    Code = 5
                });
            }

            return Ok(stakeholderResult);
        }

        [HttpPost("RegisterUserOnStakeholder")]
        public async Task<ActionResult<string>> RegisterUserOnStakeholder([FromBody] RegisterUserOnStakeholderDto registerUserOnStakeholder)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var stakeholderResult = await commandInvoker.Invoke(new GetAllStakeholdersQueryRequest
            {
                Id = registerUserOnStakeholder.StakeholderId,
            });

            if (!stakeholderResult.Status)
            {
                return BadRequest(stakeholderResult);
            }

            var user = new DataAccess.Entities.User
            {
                UserName = registerUserOnStakeholder.UserEmail,
                Email = registerUserOnStakeholder.UserEmail,
                IdStakeholder = registerUserOnStakeholder.StakeholderId,
                Name = registerUserOnStakeholder.UserName,
                Surname = registerUserOnStakeholder.UserSurname
            };

            var result = await userManager.CreateAsync(user, registerUserOnStakeholder.Password);

            if (!result.Succeeded)
            {
                StringBuilder errors = new();
                foreach (var error in result.Errors)
                {
                    errors.AppendLine(error.Description);
                }

                return BadRequest(new RegisterUserOnStakeholderResponse
                {
                    Status = false,
                    Message = errors.ToString(),
                    Code = 12
                });
            }

            return Ok(new RegisterUserOnStakeholderResponse
            {
                Status = true,
                Message = "User successfully registered on stakeholder",
                Code = 13
            });
        }
    }
}
