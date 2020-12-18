using Venda.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Venda.Infra.Data.Repository.EventSourcing
{
    public interface IEventHistoryRepository : IDisposable
    {
        void History(HistoryEvent theEvent);
        Task<IList<HistoryEvent>> All(Guid aggregateId);
    }
}