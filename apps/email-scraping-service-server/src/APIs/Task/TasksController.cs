using Microsoft.AspNetCore.Mvc;

namespace EmailScrapingService.APIs;

[ApiController()]
public class TasksController : TasksControllerBase
{
    public TasksController(ITasksService service)
        : base(service) { }
}
