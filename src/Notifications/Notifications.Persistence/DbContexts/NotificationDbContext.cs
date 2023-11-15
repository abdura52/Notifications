using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;

namespace Notifications.Persistence.DbContexts;

public class NotificationDbContext : DbContext
{
    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();

    public DbSet<SmsTemplate> SmsTemplates => Set<SmsTemplate>();

    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();

    public DbSet<SmsHistory> SmsHistories => Set<SmsHistory>();


    public NotificationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationDbContext).Assembly);
    }
}
