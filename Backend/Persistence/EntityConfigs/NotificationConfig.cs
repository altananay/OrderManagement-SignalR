using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.EntityConfigs;

public class NotificationConfig : IEntityTypeConfiguration<Notification>
{
    public void Configure(EntityTypeBuilder<Notification> builder)
    {
        builder.ToTable("Notifications").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.CreatedDate).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.Description).HasColumnName("Description");
        builder.Property(b => b.Type).HasColumnName("Type");
        builder.Property(n => n.Status).HasColumnName("Status");
        builder.Property(n => n.UIClass).HasColumnName("UIClass");
        builder.Property(n => n.Icon).HasColumnName("Icon");
    }
}