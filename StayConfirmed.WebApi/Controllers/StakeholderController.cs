using Microsoft.AspNetCore.Mvc;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Queries.StakeholderQueries.GetAllStakeholdersQuery;

namespace StayConfirmed.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class StakeholderController(CommandInvoker commandInvoker) : ControllerBase
{
    [HttpGet("GetAllStakeholders")]
    public async Task<ActionResult<string>> GetAllStakeholders()
    {
        var result = await commandInvoker.Invoke(new GetAllStakeholdersQueryRequest());
        if (!result.Status)
        {
            return BadRequest(result);
        }

        return Ok(result);
    }
}
