using Microsoft.AspNetCore.Mvc;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Commands.CsvCommands.UploadFileCommand;
using StayConfirmed.BusinessLogic.Queries.CsvQueries.ExportTemplateQuery;

namespace StayConfirmed.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CsvController(CommandInvoker commandInvoker) : ControllerBase
    {
        [HttpPost("UploadFile")]
        public async Task<IActionResult> UploadCsv(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            var result = await commandInvoker.Invoke(new UploadFileCommandRequest
            {
                File = file
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

        [HttpGet("ExportTempalate")]
        public async Task<IActionResult> ExportTempalate()
        {
            var result = await commandInvoker.Invoke(new ExportTemplateQueryRequest { });
            return File(
                result.Bytes, 
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", 
                "example1.xlsx");
        }
    }
}
