using Estoque.Domain.Core.Events;
using Estoque.Infra.Data.Context;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Estoque.Infra.Data.Repository.EventSourcing
{
    public class EventHistorySqlRepository : IEventHistoryRepository
    {
        private readonly EventHistorySqlContext _context;

        public EventHistorySqlRepository(EventHistorySqlContext context)
        {
            _context = context;
        }

        public async Task<IList<HistoryEvent>> All(Guid aggregateId)
        {
            return await (from e in _context.HistoryEvent where e.AggregateId == aggregateId select e).ToListAsync();
        }

        public void History(HistoryEvent theEvent)
        {
            _context.HistoryEvent.Add(theEvent);
            _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}