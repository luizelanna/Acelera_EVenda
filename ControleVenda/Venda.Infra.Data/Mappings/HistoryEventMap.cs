using Venda.Domain.Core.Events;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Venda.Infra.Data.Mappings
{
    public class HistoryEventMap : IEntityTypeConfiguration<HistoryEvent>
    {
        public void Configure(EntityTypeBuilder<HistoryEvent> builder)
        {
            builder.Property(c => c.Timestamp)
                .HasColumnName("CreationDate");

            builder.Property(c => c.MessageType)
                .HasColumnName("Action")
                .HasColumnType("varchar(100)");
        }
    }
}