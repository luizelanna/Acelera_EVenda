using AutoMapper;
using Estoque.Application.ViewModels;
using Estoque.Domain.Commands;

namespace Estoque.Application.AutoMapper
{
    public class ViewModelToDomainMappingProfile : Profile
    {
        public ViewModelToDomainMappingProfile()
        {
            CreateMap<ProdutoViewModel, RegisterNewProdutoCommand>()
                .ConstructUsing(c => new RegisterNewProdutoCommand(c.Codigo, c.Nome, c.Preco, c.Quantidade));
            CreateMap<ProdutoViewModel, UpdateProdutoCommand>()
                .ConstructUsing(c => new UpdateProdutoCommand(c.Id, c.Codigo, c.Nome, c.Preco, c.Quantidade));
        }
    }
}
