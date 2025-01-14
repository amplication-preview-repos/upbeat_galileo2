using EmailScrapingService.APIs;

namespace EmailScrapingService;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Add services to the container.
    /// </summary>
    public static void RegisterServices(this IServiceCollection services)
    {
        services.AddScoped<IEmailsService, EmailsService>();
        services.AddScoped<ITasksService, TasksService>();
    }
}
