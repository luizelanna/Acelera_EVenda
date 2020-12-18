using Estoque.Domain.Core.Events;
using Estoque.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infra.Data.Context
{
    public class EventHistorySqlContext : DbContext
    {
        public EventHistorySqlContext(DbContextOptions<EventHistorySqlContext> options) : base(options) { }

        public DbSet<HistoryEvent> HistoryEvent { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new HistoryEventMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}