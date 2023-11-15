using Microsoft.EntityFrameworkCore;
using Notifications.Persistence.DbContexts;
using System.Reflection;
using FluentValidation;
using Notifications.Persistence.Repositories.Interfaces;
using Notifications.Persistence.Repositories;

namespace Notifications.Api.Configuration;

public static partial class HostConfiguration
{
    private static WebApplicationBuilder AddValidators(this WebApplicationBuilder builder)
    {
        var assemblies = Assembly.GetExecutingAssembly().GetReferencedAssemblies().Select(Assembly.Load).ToList();
        assemblies.Add(Assembly.GetExecutingAssembly());


        builder.Services.AddValidatorsFromAssemblies(assemblies);

        return builder;
    }

    private static WebApplicationBuilder AddNotificationInfrastructure(this WebApplicationBuilder builder)
    {
        // register persistence
        builder.Services.AddDbContext<NotificationDbContext>(options =>
            options.UseNpgsql(builder.Configuration.GetConnectionString("NotificationsDatabaseConnection")));


        // register brokers

        // register data access foundation services
        builder.Services
            .AddScoped<IEmailHistoryRepository, EmailHistoryRepository>()
            .AddScoped<IEmailTemplateRepository, EmailTemplateRepository>()
            .AddScoped<ISmsHistoryRepository, SmsHistoryRepository>()
            .AddScoped<ISmsTemplateRepository, SmsTemplateRepository>();

        // register helper foundation services

        // register orchestration and aggregation services

        return builder;
    }

    private static WebApplicationBuilder AddExposers(this WebApplicationBuilder builder)
    {
        builder.Services.AddRouting(options => options.LowercaseUrls = true);
        builder.Services.AddControllers();

        return builder;
    }

    private static WebApplicationBuilder AddDevTools(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        return builder;
    }

    private static WebApplication UseExposers(this WebApplication app)
    {
        app.MapControllers();

        return app;
    }

    private static WebApplication UseDevTools(this WebApplication app)
    {
        app.UseSwagger();
        app.UseSwaggerUI();

        return app;
    }
}
