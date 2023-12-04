using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;

namespace Notifications.Persistence.EntityConfigurations;

public class EmailTemplateConfiguration : IEntityTypeConfiguration<EmailTemplate>
{
    public void Configure(EntityTypeBuilder<EmailTemplate> builder)
    {
        builder.HasIndex(emailTemplate => emailTemplate.NotificationTemplateType).IsUnique();

        builder.Property(template => template.Subject).HasMaxLength(256);
    }
}
