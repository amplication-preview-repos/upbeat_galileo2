using EmailScrapingService.Infrastructure;

namespace EmailScrapingService.APIs;

public class EmailsService : EmailsServiceBase
{
    public EmailsService(EmailScrapingServiceDbContext context)
        : base(context) { }
}
