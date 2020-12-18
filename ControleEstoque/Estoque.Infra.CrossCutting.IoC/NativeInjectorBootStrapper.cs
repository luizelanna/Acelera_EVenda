using Estoque.Application.Interfaces;
using Estoque.Application.Services;
using Estoque.Domain.CommandHandler;
using Estoque.Domain.Commands;
using Estoque.Domain.Core.Events;
using Estoque.Domain.EventHandlers;
using Estoque.Domain.Events;
using Estoque.Domain.Interfaces;
using Estoque.Infra.CrossCutting.Bus;
using Estoque.Infra.Data.Context;
using Estoque.Infra.Data.EventSourcing;
using Estoque.Infra.Data.Repository;
using Estoque.Infra.Data.Repository.EventSourcing;
using FluentValidation.Results;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using NetDevPack.Mediator;

namespace Estoque.Infra.CrossCutting.IoC
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
            services.AddScoped<INotificationHandler<ProdutoRemovedEvent>, ProdutoEventHandler>();

            // Domain - Commands
            services.AddScoped<IRequestHandler<RegisterNewProdutoCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<UpdateProdutoCommand, ValidationResult>, ProdutoCommandHandler>();
            services.AddScoped<IRequestHandler<VendaProdutoCommand, ValidationResult>, ProdutoCommandHandler>();

            // Infra - Data
            services.AddScoped<IProdutoRepository, ProdutoRepository>();
            services.AddScoped<EstoqueContext>();

            // Infra - Data EventSourcing
            services.AddScoped<IEventHistoryRepository, EventHistorySqlRepository>();
            services.AddScoped<IEventoHistory, SqlEventHistory>();
            services.AddScoped<EventHistorySqlContext>();
        }
    }
}