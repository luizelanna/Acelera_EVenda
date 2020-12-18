using Estoque.Domain.Commands;
using FluentValidation;
using System;

namespace Estoque.Domain.Validations
{
    public abstract class ProdutoValidation<T> : AbstractValidator<T> where T : ProdutoCommand
    {
        protected void ValidateId()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);
        }

        protected void ValidateCodigo()
        {
            RuleFor(c => c.Codigo)
                .NotEmpty().WithMessage("O Nome não pode ser vazio")
                .Length(2, 250).WithMessage("O Nome deve ter 2 até 250 caracteres");
        }
        protected void ValidateNome()
        {
            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O Nome não pode ser vazio")
                .Length(2, 250).WithMessage("O Nome deve ter 2 até 250 caracteres");
        }
        protected void ValidatePreco()
        {
            RuleFor(x => x.Preco)
                .InclusiveBetween(0, 999999999999999999).WithMessage("O preço deve ser maior que zero")
                .ScalePrecision(2, 2)
                .NotEmpty().WithMessage("Preço é obrigatório")
                .GreaterThan(0.0M).WithMessage("Preço do produto deve ser maior que zero");
        }
        protected void ValidateQuantidade()
        {
            RuleFor(c => c.Quantidade)
                .InclusiveBetween(0, 999999999999999999).WithMessage("A quantidade deve ser maior que zero")
                .ScalePrecision(2, 2)
                .NotEmpty().WithMessage("A quantidade não pode ser vazia");
                
        }
    }
}
