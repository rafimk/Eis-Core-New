using Eis.Lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Eis.Lib.Infrastructure.Persistence.Configurations;

public class CompetingConsumerGroupConfiguration : IEntityTypeConfiguration<EisCompetingConsumerGroup>
{
    public void Configure(EntityTypeBuilder<EisCompetingConsumerGroup> builder)
    {
        builder.ToTable("EIS_COMPETING_CONSUMER_GROUP");
        
        builder.HasKey(x => x.Id);
        
        builder
            .Property(x => x.Id)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("ID")
            .HasMaxLength(50);
        
        builder
            .Property(x => x.HostIpAddress)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("HOST_IP_ADDRESS")
            .HasMaxLength(255);
        
        builder
            .Property(x => x.GroupKey)
            .UsePropertyAccessMode(PropertyAccessMode.Field)
            .HasColumnName("GROUP_KEY")
            .HasMaxLength(50);

        builder.HasIndex(c => c.GroupKey).IsUnique();
    }
}