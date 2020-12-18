using Venda.Application.Interfaces;
using Venda.Application.ViewModels;
using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Venda.Services.Api.Consumer
{
    public class MessageConsumer
    {
        private readonly IProdutoAppService _produtoAppService;
        private readonly IConfiguration _configuration;
        private readonly SubscriptionClient _subscriptionClient;

        public MessageConsumer(IConfiguration configuration, IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
            _configuration = configuration;

            var connectionString = _configuration.GetSection("ServiceBus:ConnectionString").Value;
            var entityPath = _configuration.GetSection("ServiceBus:EntityPath").Value;
            var subscription = _configuration.GetSection("ServiceBus:SubscriptionName").Value;

            _subscriptionClient = new SubscriptionClient(connectionString, entityPath, subscription);
        }

        public void RegisterHandler()
        {
            var messageHandlerOptions = new MessageHandlerOptions(ExceptionHandler)
            {
                MaxConcurrentCalls = 1,
                AutoComplete = false
            };

            _subscriptionClient.RegisterMessageHandler(ProcessMessageHandler, messageHandlerOptions);
        }

        private async Task ProcessMessageHandler(Message message, CancellationToken cancellationToken)
        {
            var messageString = Encoding.UTF8.GetString(message.Body);
            var messageLabel = message.Label;

            var produtoViewModel = JsonConvert.DeserializeObject<ProdutoViewModel>(messageString);

            switch (messageLabel)
            {
                case "Create":
                    await _produtoAppService.Register(produtoViewModel);
                    break;
                case "Produto Atualizado":
                    await _produtoAppService.Update(produtoViewModel);
                    break;
                default:
                    break;
            }


            await _subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
        }

        private Task ExceptionHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
        {
            return Task.CompletedTask;
        }
    }
}