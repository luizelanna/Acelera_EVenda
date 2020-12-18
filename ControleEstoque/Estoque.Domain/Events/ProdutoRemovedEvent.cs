using NetDevPack.Messaging;
using System;

namespace Estoque.Domain.Events
{
    public class ProdutoRemovedEvent : Event
    {
        public ProdutoRemovedEvent(Guid id)
        {
            Id = id;
            AggregateId = id;
        }
        public Guid Id { get; set; }
    }
}
