using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Notifications.Domain.Entities;

namespace Notifications.Persistence.EntityConfigurations;

public class EmailHistoryConfiguration : IEntityTypeConfiguration<EmailHistory>
{
    public void Configure(EntityTypeBuilder<EmailHistory> builder)
    {
        builder.Property(history => history.SenderEmailAddress)
            .IsRequired()
            .HasMaxLength(128);

        builder.Property(history => history.ReceiverEmailAddress)
            .IsRequired()
            .HasMaxLength(128);
    }
}
