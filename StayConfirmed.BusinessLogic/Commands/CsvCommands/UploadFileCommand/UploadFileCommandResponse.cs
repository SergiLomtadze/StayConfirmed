namespace StayConfirmed.BusinessLogic.Commands.CsvCommands.UploadFileCommand;

public sealed record UploadFileCommandResponse
{
    public bool Status { get; set; }
    public string Message { get; set; }
}
