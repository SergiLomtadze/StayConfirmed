using Microsoft.AspNetCore.Http;
using StayConfirmed.BusinessLogic.CommandExecutor;

namespace StayConfirmed.BusinessLogic.Commands.CsvCommands.UploadFileCommand;

public sealed record UploadFileCommandRequest : ICommand<UploadFileCommandResponse>
{
    public IFormFile File { get; set; }
}
