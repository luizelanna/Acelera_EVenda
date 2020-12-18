using Estoque.Domain.Validations;
using System;

namespace Estoque.Domain.Commands
{
    public class VendaProdutoCommand : ProdutoCommand
    {
        public VendaProdutoCommand(Guid id, decimal quantidade)
        {
            Id = id;
            Quantidade = quantidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new VendaProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
