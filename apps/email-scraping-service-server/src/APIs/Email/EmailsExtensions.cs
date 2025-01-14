using EmailScrapingService.APIs.Dtos;
using EmailScrapingService.Infrastructure.Models;

namespace EmailScrapingService.APIs.Extensions;

public static class EmailsExtensions
{
    public static Email ToDto(this EmailDbModel model)
    {
        return new Email
        {
            CreatedAt = model.CreatedAt,
            Id = model.Id,
            UpdatedAt = model.UpdatedAt,
        };
    }

    public static EmailDbModel ToModel(
        this EmailUpdateInput updateDto,
        EmailWhereUniqueInput uniqueId
    )
    {
        var email = new EmailDbModel { Id = uniqueId.Id };

        if (updateDto.CreatedAt != null)
        {
            email.CreatedAt = updateDto.CreatedAt.Value;
        }
        if (updateDto.UpdatedAt != null)
        {
            email.UpdatedAt = updateDto.UpdatedAt.Value;
        }

        return email;
    }
}
