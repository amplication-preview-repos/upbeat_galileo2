using EmailScrapingService.Infrastructure;

namespace EmailScrapingService.APIs;

public class TasksService : TasksServiceBase
{
    public TasksService(EmailScrapingServiceDbContext context)
        : base(context) { }
}
