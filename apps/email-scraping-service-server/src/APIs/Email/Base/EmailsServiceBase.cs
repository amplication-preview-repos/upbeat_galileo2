using EmailScrapingService.APIs;
using EmailScrapingService.APIs.Common;
using EmailScrapingService.APIs.Dtos;
using EmailScrapingService.APIs.Errors;
using EmailScrapingService.APIs.Extensions;
using EmailScrapingService.Infrastructure;
using EmailScrapingService.Infrastructure.Models;
using Microsoft.EntityFrameworkCore;

namespace EmailScrapingService.APIs;

public abstract class EmailsServiceBase : IEmailsService
{
    protected readonly EmailScrapingServiceDbContext _context;

    public EmailsServiceBase(EmailScrapingServiceDbContext context)
    {
        _context = context;
    }

    /// <summary>
    /// Create one Email
    /// </summary>
    public async Task<Email> CreateEmail(EmailCreateInput createDto)
    {
        var email = new EmailDbModel
        {
            CreatedAt = createDto.CreatedAt,
            UpdatedAt = createDto.UpdatedAt
        };

        if (createDto.Id != null)
        {
            email.Id = createDto.Id;
        }

        _context.Emails.Add(email);
        await _context.SaveChangesAsync();

        var result = await _context.FindAsync<EmailDbModel>(email.Id);

        if (result == null)
        {
            throw new NotFoundException();
        }

        return result.ToDto();
    }

    /// <summary>
    /// Delete one Email
    /// </summary>
    public async Task DeleteEmail(EmailWhereUniqueInput uniqueId)
    {
        var email = await _context.Emails.FindAsync(uniqueId.Id);
        if (email == null)
        {
            throw new NotFoundException();
        }

        _context.Emails.Remove(email);
        await _context.SaveChangesAsync();
    }

    /// <summary>
    /// Find many Emails
    /// </summary>
    public async Task<List<Email>> Emails(EmailFindManyArgs findManyArgs)
    {
        var emails = await _context
            .Emails.ApplyWhere(findManyArgs.Where)
            .ApplySkip(findManyArgs.Skip)
            .ApplyTake(findManyArgs.Take)
            .ApplyOrderBy(findManyArgs.SortBy)
            .ToListAsync();
        return emails.ConvertAll(email => email.ToDto());
    }

    /// <summary>
    /// Meta data about Email records
    /// </summary>
    public async Task<MetadataDto> EmailsMeta(EmailFindManyArgs findManyArgs)
    {
        var count = await _context.Emails.ApplyWhere(findManyArgs.Where).CountAsync();

        return new MetadataDto { Count = count };
    }

    /// <summary>
    /// Get one Email
    /// </summary>
    public async Task<Email> Email(EmailWhereUniqueInput uniqueId)
    {
        var emails = await this.Emails(
            new EmailFindManyArgs { Where = new EmailWhereInput { Id = uniqueId.Id } }
        );
        var email = emails.FirstOrDefault();
        if (email == null)
        {
            throw new NotFoundException();
        }

        return email;
    }

    /// <summary>
    /// Update one Email
    /// </summary>
    public async Task UpdateEmail(EmailWhereUniqueInput uniqueId, EmailUpdateInput updateDto)
    {
        var email = updateDto.ToModel(uniqueId);

        _context.Entry(email).State = EntityState.Modified;

        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateConcurrencyException)
        {
            if (!_context.Emails.Any(e => e.Id == email.Id))
            {
                throw new NotFoundException();
            }
            else
            {
                throw;
            }
        }
    }
}
