using Estoque.Domain.Commands;

namespace Estoque.Domain.Validations
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
