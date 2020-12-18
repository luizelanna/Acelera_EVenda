using Venda.Application.Interfaces;
using Venda.Application.Services;
using Venda.Domain.CommandHandler;
using Venda.Domain.Commands;
using Venda.Domain.Core.Events;
using Venda.Domain.EventHandlers;
using Venda.Domain.Events;
using Venda.Domain.Interfaces;
using Venda.Infra.CrossCutting.Bus;
using Venda.Infra.Data.Context;
using Venda.Infra.Data.EventSourcing;
using Venda.Infra.Data.Repository;
using Venda.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Venda.Infra.CrossCutting.IoC
{
    public static class NativeInjectorBootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Domain Bus (Mediator)
            services.AddScoped<IMediatorHandler, InMemoryBus>();

            // Application
            services.AddScoped<IProdutoAppService, ProdutoAppService>();

            // Domain - Events
            services.AddScoped<INotificationHandler<ProdutoRegisteredEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<ProdutoUpdateEvent>, ProdutoEventHandler>();
            services.AddScoped<INotificationHandler<ProdutoVendaEvent>, ProdutoEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProdutoCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProdutoCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<VendaProdutoCommand, ValidationResult>, ProdutoCommandHandler>();

            // Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<VendaContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventHistoryRepository, EventHistorySqlRepository>();
            services.AddScoped<IEventoHistory, SqlEventHistory>();
            services.AddScoped<EventHistorySqlContext>();
        }
    }
}