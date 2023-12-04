using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;
using Type = Notifications.Domain.Enums.NotificationType;
namespace Notifications.Persistence.EntityConfigurations;

public class NotificationTemplateConfiguration : IEntityTypeConfiguration<NotificationTemplate>
{
    public void Configure(EntityTypeBuilder<NotificationTemplate> builder)
    {
        builder.HasIndex(template => template.NotificationType).IsUnique();

        //builder.Property(template => template.Content).HasMaxLength(256);

        builder
            .HasDiscriminator(template => template.NotificationType)
            .HasValue<EmailTemplate>(Type.Email)
            .HasValue<SmsTemplate>(Type.Sms);
    }
}
