using NetDevPack.Messaging;
using System;

namespace Venda.Domain.Events
{
    public class ProdutoRegisteredEvent : Event
    {
        public ProdutoRegisteredEvent(Guid id, string codigo, string nome, decimal preco, decimal quantidade)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public Guid Id{ get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}
