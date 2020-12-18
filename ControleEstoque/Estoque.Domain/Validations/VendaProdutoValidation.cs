using Estoque.Domain.Commands;

namespace Estoque.Domain.Validations
{
    public class VendaProdutoValidation : ProdutoValidation<VendaProdutoCommand>
    {
        public VendaProdutoValidation()
        {
            ValidateId();
            ValidateQuantidade();
        }
    }
}
