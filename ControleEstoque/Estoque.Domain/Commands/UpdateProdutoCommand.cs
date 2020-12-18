using Estoque.Domain.Validations;
using System;

namespace Estoque.Domain.Commands
{
    public class UpdateProdutoCommand : ProdutoCommand
    {
        public UpdateProdutoCommand(Guid id, string codigo, string nome, decimal preco, decimal quantidade)
        {
            Id = id;
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new UpdateProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
