using EmailScrapingService.APIs.Common;
using EmailScrapingService.Infrastructure.Models;
using Microsoft.AspNetCore.Mvc;

namespace EmailScrapingService.APIs.Dtos;

[BindProperties(SupportsGet = true)]
public class TaskFindManyArgs : FindManyInput<Task, TaskWhereInput> { }
