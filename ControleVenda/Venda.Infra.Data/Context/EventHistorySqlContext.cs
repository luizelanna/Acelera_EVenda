using Venda.Domain.Core.Events;
using Venda.Infra.Data.Mappings;
using Microsoft.EntityFrameworkCore;

namespace Venda.Infra.Data.Context
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