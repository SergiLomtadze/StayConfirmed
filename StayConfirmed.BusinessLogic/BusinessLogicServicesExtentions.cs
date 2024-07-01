using Microsoft.Extensions.DependencyInjection;
using StayConfirmed.BusinessLogic.CommandExecutor;
using StayConfirmed.BusinessLogic.Commands.UserCommands.ActivateUserCommands;
using StayConfirmed.BusinessLogic.Commands.UserCommands.UserActivationCommand;
using StayConfirmed.BusinessLogic.Queries.UserQueries.GetUserQuery;
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
    }
}