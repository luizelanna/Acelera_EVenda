using Estoque.Domain.Events;
using Estoque.Domain.Models;
using Estoque.Domain.Utils;
using MediatR;
using Microsoft.Azure.ServiceBus;   
using Newtonsoft.Json;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Estoque.Domain.EventHandlers
{
    public class ProdutoEventHandler :
         INotificationHandler<ProdutoRegisteredEvent>,
         INotificationHandler<ProdutoUpdateEvent>,
         INotificationHandler<ProdutoRemovedEvent>
    {

        public Task Handle(ProdutoRegisteredEvent notification, CancellationToken cancellationToken)
        {
            var produtoAtualizado = new Produto(notification.Id, notification.Codigo, notification.Nome, notification.Preco, notification.Quantidade);

            var serviceBusClient = new TopicClient("Endpoint=sb://luizaceleracao.servicebus.windows.net/;SharedAccessKeyName=OuvirProduto;SharedAccessKey=09A0o4RrkcqvntrjBOcNzyBkjDNYeNGcbtseg3zI9gw=", "OuvirProduto");

            var NomeEvento = "Create";
            var jsonMessage = JsonConvert.SerializeObject(produtoAtualizado);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            var mensagem = new Message
            {
                ContentType = "application/json",
                CorrelationId = Guid.NewGuid().ToString(),
                Body = body,
                Label = NomeEvento
            };

            serviceBusClient.SendAsync(mensagem);
            return Task.CompletedTask;
        }

        public Task Handle(ProdutoUpdateEvent notification, CancellationToken cancellationToken)
        {
            var serviceBusClient = new TopicClient("Endpoint=sb://luizaceleracao.servicebus.windows.net/;SharedAccessKeyName=OuvirProduto;SharedAccessKey=09A0o4RrkcqvntrjBOcNzyBkjDNYeNGcbtseg3zI9gw=", "OuvirProduto");

            var NomeEvento = "Produto Atualizado";
            var jsonMessage = JsonConvert.SerializeObject(notification);
            var body = Encoding.UTF8.GetBytes(jsonMessage);

            var mensagem = new Message
            {
                ContentType = "application/json",
                CorrelationId = Guid.NewGuid().ToString(),
                Body = body,
                Label = NomeEvento
            };

            serviceBusClient.SendAsync(mensagem);
            return Task.CompletedTask;
        }

        public Task Handle(ProdutoRemovedEvent notification, CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
