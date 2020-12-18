using Estoque.Domain.Core.Events;
using Estoque.Infra.Data.Repository.EventSourcing;
using NetDevPack.Identity.User;
using NetDevPack.Messaging;
using Newtonsoft.Json;

namespace Estoque.Infra.Data.EventSourcing
{
    public class SqlEventHistory : IEventoHistory
    {
        private readonly IEventHistoryRepository _eventHistoryRepository;
        private readonly IAspNetUser _user;

        public SqlEventHistory(IEventHistoryRepository eventHistoryRepository, IAspNetUser user)
        {
            _eventHistoryRepository = eventHistoryRepository;
            _user = user;
        }

        public void Save<T>(T theEvent) where T : Event
        {
            // Using Newtonsoft.Json because System.Text.Json
            // is a sad joke and far to be considered "Done"
            var serializedData = JsonConvert.SerializeObject(theEvent);

            var storedEvent = new HistoryEvent(
                theEvent,
                serializedData,
                _user.Name ?? _user.GetUserEmail());

            _eventHistoryRepository.History(storedEvent);
        }
    }
}