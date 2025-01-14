using EmailScrapingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailScrapingService.Infrastructure;

public class EmailScrapingServiceDbContext : DbContext
{
    public EmailScrapingServiceDbContext(DbContextOptions<EmailScrapingServiceDbContext> options)
        : base(options) { }

    public DbSet<TaskDbModel> Tasks { get; set; }

    public DbSet<EmailDbModel> Emails { get; set; }
}
