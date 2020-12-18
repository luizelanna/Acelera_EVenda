using Estoque.Domain.Commands;
using Estoque.Domain.Validations;

namespace Estoque.Domain.Validations
{
    public class RegisterNewProdutoValidation : ProdutoValidation<RegisterNewProdutoCommand>
    {
        public RegisterNewProdutoValidation()
        {
            ValidateCodigo();
            ValidateNome();
            ValidatePreco();
            ValidateQuantidade();
        }
    }
}
