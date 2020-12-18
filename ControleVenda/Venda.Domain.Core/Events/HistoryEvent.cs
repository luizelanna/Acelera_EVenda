using NetDevPack.Messaging;
using System;

namespace Venda.Domain.Core.Events
{
    public class HistoryEvent : Event
    {
        public HistoryEvent(Event theEvent, string data, string user)
        {
            Id = Guid.NewGuid();
            AggregateId = theEvent.AggregateId;
            MessageType = theEvent.MessageType;
            Data = data;
            User = user;
        }

        // EF Constructor
        protected HistoryEvent() { }

        public Guid Id { get; private set; }

        public string Data { get; private set; }

        public string User { get; private set; }
    }
}