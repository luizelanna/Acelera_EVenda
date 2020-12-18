using Venda.Domain.Commands;
using Venda.Domain.Validations;

namespace Venda.Domain.Validations
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
