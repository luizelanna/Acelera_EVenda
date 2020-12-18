using System;
using NetDevPack.Domain;

namespace Venda.Domain.Models
{
    public class Produto : Entity, IAggregateRoot
    {
        public Produto(Guid id, string codigo, string nome, decimal preco, decimal quantidade)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }
        public string Codigo { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public decimal Quantidade { get; set; }
    }
}
