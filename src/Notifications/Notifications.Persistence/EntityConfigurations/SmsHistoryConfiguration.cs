using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;

namespace Notifications.Persistence.EntityConfigurations;

public class SmsHistoryConfiguration : IEntityTypeConfiguration<SmsHistory>
{
    public void Configure(EntityTypeBuilder<SmsHistory> builder)
    {
        builder.Property(history => history.SenderPhoneNumber)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(history => history.ReceiverPhoneNumber)
           .IsRequired()
           .HasMaxLength(128);
    }
}
