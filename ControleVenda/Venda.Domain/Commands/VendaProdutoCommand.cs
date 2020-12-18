using Venda.Domain.Validations;
using System;

namespace Venda.Domain.Commands
{
    public class VendaProdutoCommand : ProdutoCommand
    {
        public VendaProdutoCommand(Guid id, decimal quantidade)
        {
            Id = id;
            Quantidade = quantidade;
            AggregateId = id;
        }

        public override bool IsValid()
        {
            ValidationResult = new RemoveProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
