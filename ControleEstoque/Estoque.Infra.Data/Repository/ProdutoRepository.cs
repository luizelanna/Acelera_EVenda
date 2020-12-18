using Estoque.Domain.Interfaces;
using Estoque.Domain.Models;
using Estoque.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using NetDevPack.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Infra.Data.Repository
{
    public class ProdutoRepository : IProdutoRepository
    {
        protected readonly EstoqueContext Db;
        protected readonly DbSet<Produto> DbSet;
        public IUnitOfWork UnitOfWork => Db;

        public ProdutoRepository(EstoqueContext context)
        {
            Db = context;
            DbSet = Db.Set<Produto>();
        }

        public void add(Produto produto)
        {
            DbSet.Add(produto);
        }

        public async void Dispose()
        {
            await Db.DisposeAsync();
        }

        public async Task<IEnumerable<Produto>> GetAll()
        {
            return await DbSet.ToListAsync();
        }

        public async Task<Produto> GetById(Guid id)
        {
            return await DbSet
                .FindAsync(id);
        }

        public async Task<Produto> GetCodigo(string codigo)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Codigo.ToLower().Equals(codigo.ToLower()));
        }

        public async Task<Produto> GetNome(string nome)
        {
            return await DbSet.AsNoTracking().FirstOrDefaultAsync(c => c.Nome.ToLower().Equals(nome.ToLower()));
        }

        public void Vendido(Produto produto)
        {
            DbSet.Update(produto);
        }

        public void Update(Produto produto)
        {
            DbSet.Update(produto);
        }
    }
}
