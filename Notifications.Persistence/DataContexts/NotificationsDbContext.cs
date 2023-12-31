﻿using Microsoft.EntityFrameworkCore;
using Notifications.Domain.Entities;

namespace Notifications.Persistence.DataContexts;

public class NotificationsDbContext : DbContext
{
    public DbSet<User> Users => Set<User>();

    public DbSet<EmailTemplate> EmailTemplates => Set<EmailTemplate>();

    public DbSet<SmsTemplate> SmsTemplates => Set<SmsTemplate>();

    public DbSet<EmailHistory> EmailHistories => Set<EmailHistory>();

    public DbSet<SmsHistory> SmsHistories => Set<SmsHistory>();

    public NotificationsDbContext(DbContextOptions contextOptions) : base(contextOptions)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder) =>
       modelBuilder.ApplyConfigurationsFromAssembly(typeof(NotificationsDbContext).Assembly);
}