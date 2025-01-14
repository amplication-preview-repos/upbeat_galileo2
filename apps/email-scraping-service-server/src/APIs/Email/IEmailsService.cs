using EmailScrapingService.APIs.Common;
using EmailScrapingService.APIs.Dtos;

namespace EmailScrapingService.APIs;

public interface IEmailsService
{
    /// <summary>
    /// Create one Email
    /// </summary>
    public Task<Email> CreateEmail(EmailCreateInput email);

    /// <summary>
    /// Delete one Email
    /// </summary>
    public Task DeleteEmail(EmailWhereUniqueInput uniqueId);

    /// <summary>
    /// Find many Emails
    /// </summary>
    public Task<List<Email>> Emails(EmailFindManyArgs findManyArgs);

    /// <summary>
    /// Meta data about Email records
    /// </summary>
    public Task<MetadataDto> EmailsMeta(EmailFindManyArgs findManyArgs);

    /// <summary>
    /// Get one Email
    /// </summary>
    public Task<Email> Email(EmailWhereUniqueInput uniqueId);

    /// <summary>
    /// Update one Email
    /// </summary>
    public Task UpdateEmail(EmailWhereUniqueInput uniqueId, EmailUpdateInput updateDto);
}
