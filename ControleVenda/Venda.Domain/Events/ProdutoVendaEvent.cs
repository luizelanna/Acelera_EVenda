using NetDevPack.Messaging;
using System;

namespace Venda.Domain.Events
{
    public class ProdutoVendaEvent : Event
    {
        public ProdutoVendaEvent(Guid id, decimal quantidade)
        {
            Id = id;
            Quantidade = quantidade;
        }
        public Guid Id { get; set; }
        public decimal Quantidade { get; set; }
    }
}
