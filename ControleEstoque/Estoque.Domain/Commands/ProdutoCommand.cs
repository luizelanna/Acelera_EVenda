using NetDevPack.Messaging;
using System;

namespace Estoque.Domain.Commands
{
    public class ProdutoCommand : Command
    {
        public Guid Id { get; set; }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}
