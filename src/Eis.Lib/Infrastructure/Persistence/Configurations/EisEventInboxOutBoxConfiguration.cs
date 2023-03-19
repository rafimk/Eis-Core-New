using Eis.Lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eis.Lib.Infrastructure.Persistence.Configurations;

public class EisEventInboxOutBoxConfiguration : IEntityTypeConfiguration<EisEventInboxOutBox>
{
    public void Configure(EntityTypeBuilder<EisEventInboxOutBox> builder)
    {
        builder.ToTable("EIS_EVENT_INBOX_OUTBOX");
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ID")
            .HasMaxLength(50);
        
        builder
            .Property(x => x.EventId)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("EVENT_ID")
            .HasMaxLength(255);
        
        builder
            .Property(x => x.TopicQueueName)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("TOPIC_QUEUE_NAM")
            .HasMaxLength(255);
        
        builder
            .Property(x => x.EisEvent)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("EIS_EVENT");
        
        builder
            .Property(x => x.IsEventProcessed)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("IS_EVENT_PROCESSED")
            .HasMaxLength(50);
        
        builder
            .Property(x => x.InOut)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("IN_OUT")
            .HasMaxLength(3);

        builder.HasAlternateKey(x => new [] { x.EventId, x.TopicQueueName}).HasName("EIS_EVENT_INBOX_OUTBOX_UK");;
    }
}