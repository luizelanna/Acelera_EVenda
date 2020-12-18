using AutoMapper;
using Estoque.Application.ViewModels;
using Estoque.Domain.Models;

namespace Estoque.Application.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {
            CreateMap<Produto, ProdutoViewModel>();
        }
    }
}
