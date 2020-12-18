using Estoque.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Infra.Data.Repository.EventSourcing
{
    public interface IEventHistoryRepository : IDisposable
    {
        void History(HistoryEvent theEvent);
        Task<IList<HistoryEvent>> All(Guid aggregateId);
    }
}