using Estoque.Application.HistorySourcedNormalizers;
using Estoque.Application.ViewModels;
using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Estoque.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        Task<IEnumerable<ProdutoViewModel>> GetAll();
        Task<ProdutoViewModel> GetById(Guid id);

        Task<ValidationResult> Register(ProdutoViewModel customerViewModel);
        Task<ValidationResult> Update(ProdutoViewModel customerViewModel);
        Task<ValidationResult> Venda(Guid id, decimal quantidade);

        Task<IList<ProdutoHistoryData>> GetAllHistory(Guid id);
    }
}