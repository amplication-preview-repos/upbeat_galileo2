using Microsoft.AspNetCore.Mvc;

namespace EmailScrapingService.APIs;

[ApiController()]
public class EmailsController : EmailsControllerBase
{
    public EmailsController(IEmailsService service)
        : base(service) { }
}
