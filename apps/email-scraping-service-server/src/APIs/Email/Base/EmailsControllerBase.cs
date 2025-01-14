using EmailScrapingService.APIs;
using EmailScrapingService.APIs.Common;
using EmailScrapingService.APIs.Dtos;
using EmailScrapingService.APIs.Errors;
using Microsoft.AspNetCore.Mvc;

namespace EmailScrapingService.APIs;

[Route("api/[controller]")]
[ApiController()]
public abstract class EmailsControllerBase : ControllerBase
{
    protected readonly IEmailsService _service;

    public EmailsControllerBase(IEmailsService service)
    {
        _service = service;
    }

    /// <summary>
    /// Create one Email
    /// </summary>
    [HttpPost()]
    public async Task<ActionResult<Email>> CreateEmail(EmailCreateInput input)
    {
        var email = await _service.CreateEmail(input);

        return CreatedAtAction(nameof(Email), new { id = email.Id }, email);
    }

    /// <summary>
    /// Delete one Email
    /// </summary>
    [HttpDelete("{Id}")]
    public async Task<ActionResult> DeleteEmail([FromRoute()] EmailWhereUniqueInput uniqueId)
    {
        try
        {
            await _service.DeleteEmail(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }

    /// <summary>
    /// Find many Emails
    /// </summary>
    [HttpGet()]
    public async Task<ActionResult<List<Email>>> Emails([FromQuery()] EmailFindManyArgs filter)
    {
        return Ok(await _service.Emails(filter));
    }

    /// <summary>
    /// Meta data about Email records
    /// </summary>
    [HttpPost("meta")]
    public async Task<ActionResult<MetadataDto>> EmailsMeta([FromQuery()] EmailFindManyArgs filter)
    {
        return Ok(await _service.EmailsMeta(filter));
    }

    /// <summary>
    /// Get one Email
    /// </summary>
    [HttpGet("{Id}")]
    public async Task<ActionResult<Email>> Email([FromRoute()] EmailWhereUniqueInput uniqueId)
    {
        try
        {
            return await _service.Email(uniqueId);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }
    }

    /// <summary>
    /// Update one Email
    /// </summary>
    [HttpPatch("{Id}")]
    public async Task<ActionResult> UpdateEmail(
        [FromRoute()] EmailWhereUniqueInput uniqueId,
        [FromQuery()] EmailUpdateInput emailUpdateDto
    )
    {
        try
        {
            await _service.UpdateEmail(uniqueId, emailUpdateDto);
        }
        catch (NotFoundException)
        {
            return NotFound();
        }

        return NoContent();
    }
}
