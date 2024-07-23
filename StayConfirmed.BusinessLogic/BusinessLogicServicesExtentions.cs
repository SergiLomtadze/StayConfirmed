using Microsoft.Extensions.DependencyInjection;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Commands.CsvCommands.UploadFileCommand;
using StayConfirmed.BusinessLogic.Commands.RegistrationCommands.RegisterCommand;
using StayConfirmed.BusinessLogic.Commands.StakeholderCommands.DeleteStakeholderCommand;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ActivateUserCommands;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ForgotPassowrdCommand;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ResetPasswordCommand;
using StayConfirmed.BusinessLogic.Commands.UserCommands.UserActivationCommand;
using StayConfirmed.BusinessLogic.Queries.CsvQueries.ExportTemplateQuery;
using StayConfirmed.BusinessLogic.Queries.StakeholderQueries.GetAllStakeholdersQuery;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserQuery;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUsersByStakeholderIdQuery;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserStatusQuery;

namespace StayConfirmed.BusinessLogic;

public static class BusinessLogicServicesExtentions
{
    public static void AddBusinessLogicServices(this IServiceCollection services)
    {
        services.AddScoped<CommandInvoker>();
        services.AddScoped<ICommandHandler<GetUserQueryRequest, GetUserQueryResponse>, GetUserQueryHandler>();
        services.AddScoped<ICommandHandler<GetUserStatusQueryRequest, GetUserStatusQueryResponse>, GetUserStatusQueryHandler>();
        services.AddScoped<ICommandHandler<ActivateUserCommandRequest, ActivateUserCommandResponse>, ActivateUserCommandHandler>();
        services.AddScoped<ICommandHandler<UserActivationCommandRequest, UserActivationCommandResponse>, UserActivationCommandHandler>();
        services.AddScoped<ICommandHandler<UploadFileCommandRequest, UploadFileCommandResponse>, UploadFileCommandHandler>();
        services.AddScoped<ICommandHandler<ExportTemplateQueryRequest, ExportTemplateQueryResponse>, ExportTemplateQueryHandler>();
        services.AddScoped<ICommandHandler<ForgotPasswordCommandRequest, ForgotPasswordCommandResponse>, ForgotPasswordCommandHandler>();
        services.AddScoped<ICommandHandler<ResetPasswordCommandRequest, ResetPasswordCommandResponse>, ResetPasswordCommandHandler>();
        services.AddScoped<ICommandHandler<RegisterStakeholderCommandRequest, RegisterStakeholderCommandResponse>, RegisterStakeholderCommandHandler>();
        services.AddScoped<ICommandHandler<DeleteStakeholderCommandRequest, DeleteStakeholderCommandResponse>, DeleteStakeholderCommandHandler>();
        services.AddScoped<ICommandHandler<GetAllStakeholdersQueryRequest, GetAllStakeholdersQueryResponse>, GetAllStakeholdersQueryHandler>();
        services.AddScoped<ICommandHandler<GetUsersByStakeholderIdQueryRequest, GetUsersByStakeholderIdQueryResponse>, GetUsersByStakeholderIdQueryHandler>();
    }
}