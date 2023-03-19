using Eis.Lib.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Eis.Lib.Infrastructure.Persistence;

public class EisDbContext : DbContext
{
    public DbSet<EisEventInboxOutBox> TodoLists => Set<EisEventInboxOutBox>();

    public DbSet<EisCompetingConsumerGroup> TodoItems => Set<EisCompetingConsumerGroup>();
    
    public EisDbContext(DbContextOptions<EisDbContext> options) : base(options)
    {
    }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EisDbContext).Assembly);
    }
}