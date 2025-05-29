using CoachApp.DAL.Data;
using CoachApp.DAL.Data.Extensions;
using CoachApp.DAL.Data.Models;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CoachApp.Services;

public static class DependencyInjection
{
    public static IServiceCollection AddDatabaseServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<CoachAppContext>(options =>
        {
            options.UseSqlServer(configuration.GetConnectionString("CoachAppDb")); // Fixed typo in GetConnectionString
        });
        return services;
    }

    public static IServiceCollection AddIdentityServices(this IServiceCollection services)
    {
        services.AddIdentityCore<User, IdentityRole<int>>()
                .AddEntityFrameworkStores<CoachAppContext>()
                .AddDefaultTokenProviders();
    }

    public static IServiceProvider AddDatabaseServicesProvider(this IServiceProvider serviceProvider)
    {
        using (var scope = serviceProvider.CreateScope())
        {
            var context = scope.ServiceProvider.GetRequiredService<CoachAppContext>();
            context.Database.EnsureCreated();
            DbSeeder.SeedDatabase(context);
        }
        return serviceProvider;
    }

}