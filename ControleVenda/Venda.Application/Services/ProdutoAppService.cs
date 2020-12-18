using AutoMapper;
using Venda.Application.HistorySourcedNormalizers;
using Venda.Application.Interfaces;
using Venda.Application.ViewModels;
using Venda.Domain.Commands;
using Venda.Domain.Interfaces;
using Venda.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using NetDevPack.Mediator;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Venda.Application.Services
{
   public class ProdutoAppService : IProdutoAppService
    {
        private readonly IMapper _mapper;
        private readonly IProdutoRepository _customerRepository;
        private readonly IEventHistoryRepository _eventHistoryRepository;
        private readonly IMediatorHandler _mediator;

        public ProdutoAppService(IMapper mapper,
                                  IProdutoRepository customerRepository,
                                  IMediatorHandler mediator,
                                  IEventHistoryRepository eventHistoryRepository)
        {
            _mapper = mapper;
            _customerRepository = customerRepository;
            _mediator = mediator;
            _eventHistoryRepository = eventHistoryRepository;
        }

        public async Task<IEnumerable<ProdutoViewModel>> GetAll()
        {
            return _mapper.Map<IEnumerable<ProdutoViewModel>>(await _customerRepository.GetAll());
        }

        public async Task<ProdutoViewModel> GetById(Guid id)
        {
            return _mapper.Map<ProdutoViewModel>(await _customerRepository.GetById(id));
        }

        public async Task<ValidationResult> Register(ProdutoViewModel customerViewModel)
        {
            var registerCommand = _mapper.Map<RegisterNewProdutoCommand>(customerViewModel);
            return await _mediator.SendCommand(registerCommand);
        }

        public async Task<ValidationResult> Update(ProdutoViewModel customerViewModel)
        {
            var updateCommand = _mapper.Map<UpdateProdutoCommand>(customerViewModel);
            return await _mediator.SendCommand(updateCommand);
        }

        public async Task<ValidationResult> Venda(Guid id, decimal quantidade)
        {
            var removeCommand = new VendaProdutoCommand(id, quantidade);
            return await _mediator.SendCommand(removeCommand);
        }

        public async Task<IList<ProdutoHistoryData>> GetAllHistory(Guid id)
        {
            return ProdutoHistory.ToJavaScriptProdutoHistory(await _eventHistoryRepository.All(id));
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
