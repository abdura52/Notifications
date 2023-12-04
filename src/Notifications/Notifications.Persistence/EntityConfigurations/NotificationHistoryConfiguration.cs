using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;
using Notifications.Domain.Enums;

namespace Notifications.Persistence.EntityConfigurations;

public class NotificationHistoryConfiguration : IEntityTypeConfiguration<NotificationHistory>
{
    public void Configure(EntityTypeBuilder<NotificationHistory> builder)
    {
        builder.HasDiscriminator(history => history.NotificationType)
            .HasValue<EmailHistory>(NotificationType.Email)
            .HasValue<SmsHistory>(NotificationType.Sms);

        builder.HasOne(history => history.Template)
           .WithMany(template => template.Histories)
           .HasForeignKey(history => history.TemplateId);

    }
}
