using System;
using System.Threading;
using System.Threading.Tasks;
using Venda.Domain.Commands;
using Venda.Domain.Events;
using Venda.Domain.Interfaces;
using Venda.Domain.Models;
using FluentValidation.Results;
using MediatR;


namespace Venda.Domain.CommandHandler
{
    public class ProdutoCommandHandler : NetDevPack.Messaging.CommandHandler,
        IRequestHandler<RegisterNewProdutoCommand, ValidationResult>,
        IRequestHandler<UpdateProdutoCommand, ValidationResult>,
        IRequestHandler<VendaProdutoCommand, ValidationResult>
    {
        private readonly IProdutoRepository _produtorepository;

        public ProdutoCommandHandler(IProdutoRepository produtorepository)
        {
            _produtorepository = produtorepository;
        }

        public async Task<ValidationResult> Handle(RegisterNewProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var produto = new Produto(Guid.NewGuid(), request.Codigo, request.Nome, request.Preco, request.Quantidade);

            if (await _produtorepository.GetCodigo(produto.Codigo) != null)
            {
                AddError("Código do produto já cadastrado");
                return ValidationResult;
            }//implementar posteriormente fluenteValidation para retirar desta classe esta validação
            if (await _produtorepository.GetNome(produto.Nome) != null)
            {
                AddError("Nome do produto já Cadastrado");
                return ValidationResult;
            }

            _produtorepository.add(produto);

            return await Commit(_produtorepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(UpdateProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var produto = new Produto(request.Id, request.Codigo, request.Nome, request.Preco, request.Quantidade);
            var existingProduto = await _produtorepository.GetCodigo(produto.Codigo);
            if (existingProduto is null)
            {
                AddError("O produto não existe.");
                return ValidationResult;
            }

            _produtorepository.Update(produto);

            //var validation = await Commit(_produtorepository.UnitOfWork);

            //if (validation.IsValid)
            //{
            //    produto.AddDomainEvent(new ProdutoUpdateEvent(produto.Id, produto.Codigo, produto.Nome, produto.Preco, produto.Quantidade));
            //}

            return await Commit(_produtorepository.UnitOfWork);
        }

        public async Task<ValidationResult> Handle(VendaProdutoCommand request, CancellationToken cancellationToken)
        {
            if (!request.IsValid())
            {
                return request.ValidationResult;
            }

            var produto = await _produtorepository.GetById(request.Id);

            if (produto is null)
            {
                AddError("O produto não existe.");
                return ValidationResult;
            }
            if (produto.Quantidade < request.Quantidade)
            {
                AddError("Quantidade maior do que a quantidade em estoque.");
                return ValidationResult;
            }
            produto.Quantidade -= request.Quantidade;

            _produtorepository.Vendido(produto);

            var validation = await Commit(_produtorepository.UnitOfWork);

            if (validation.IsValid)
            {
                produto.AddDomainEvent(new ProdutoVendaEvent(produto.Id, produto.Quantidade));
            }

            return validation;
        }

        public void Dispose()
        {
            _produtorepository.Dispose();
        }
    }
}
