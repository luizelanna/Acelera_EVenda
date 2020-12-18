using Estoque.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Estoque.Domain.Commands
{
    public class RegisterNewProdutoCommand : ProdutoCommand
    {
        public RegisterNewProdutoCommand(string codigo, string nome, decimal preco, decimal quantidade)
        {
            Codigo = codigo;
            Nome = nome;
            Preco = preco;
            Quantidade = quantidade;
        }

        public override bool IsValid()
        {
            ValidationResult = new RegisterNewProdutoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
