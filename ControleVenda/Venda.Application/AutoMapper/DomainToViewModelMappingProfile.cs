using AutoMapper;
using Venda.Application.ViewModels;
using Venda.Domain.Models;

namespace Venda.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
