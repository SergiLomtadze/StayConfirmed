using Microsoft.Extensions.DependencyInjection;
using StayConfirmed.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using StayConfirmed.BusinessLogic.Interfaces;
namespace StayConfirmed.Persistence;

public static class PersistenceServiceExtentions
{
    public static void AddPersistenceServices(this IServiceCollection services)
    {
        services.AddDbContext<ApplicationDbContext>((s, option) =>
            option.UseSqlServer(s.GetRequiredService<IConfiguration>().GetConnectionString("DefaultConnection")));
        services.AddScoped<IApplicationDbContext, ApplicationDbContext>();
    }
}
