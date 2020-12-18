using Venda.Domain.Commands;

namespace Venda.Domain.Validations
{
    public class RemoveProdutoValidation : ProdutoValidation<VendaProdutoCommand>
    {
        public RemoveProdutoValidation()
        {
            ValidateId();
        }
    }
}
