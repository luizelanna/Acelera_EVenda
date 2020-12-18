using Venda.Domain.Models;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Venda.Domain.Interfaces
{
    public  interface IProdutoRepository : IRepository<Produto>
    {
        Task<Produto> GetById(Guid id);
        Task<Produto> GetCodigo(string codigo);
        Task<Produto> GetNome(string nome);
        Task<IEnumerable<Produto>> GetAll();

        void add(Produto produto);
        void Update(Produto produto);
        void Vendido(Produto produto);
    }
}
