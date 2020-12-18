using Venda.Domain.Commands;

namespace Venda.Domain.Validations
{
    public class UpdateProdutoValidation : ProdutoValidation<UpdateProdutoCommand>
    {
        public UpdateProdutoValidation()
        {
            ValidateId();
            ValidateCodigo();
            ValidateNome();
            ValidatePreco();
            ValidateQuantidade();
        }
    }
}
