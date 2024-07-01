using Microsoft.Extensions.DependencyInjection;

namespace StayConfirmed.BusinessLogic.CommandExecutor;

public class CommandInvoker(IServiceProvider serviceProvider)
{
    public Task<TResult> Invoke<TResult>(ICommand<TResult> command)
    {
        return InvokeCore((dynamic)command, default(TResult));
    }

    private Task<TResult> InvokeCore<TCommand, TResult>(TCommand command, TResult result) where TCommand : ICommand<TResult>
    {
        var handler = serviceProvider.GetRequiredService<ICommandHandler<TCommand, TResult>>();
        return handler.Handle(command);
    }

}