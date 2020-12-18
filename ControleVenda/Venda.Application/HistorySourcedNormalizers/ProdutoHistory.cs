using Venda.Domain.Core.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace Venda.Application.HistorySourcedNormalizers
{
    public static class ProdutoHistory
    {
        public static IList<ProdutoHistoryData> HistoryData { get; set; }

        public static IList<ProdutoHistoryData> ToJavaScriptProdutoHistory(IList<HistoryEvent> historyEvents)
        {
            HistoryData = new List<ProdutoHistoryData>();
            ProdutoHistoryDeserializer(historyEvents);

            var sorted = HistoryData.OrderBy(c => c.Timestamp);
            var list = new List<ProdutoHistoryData>();
            var last = new ProdutoHistoryData();

            foreach (var change in sorted)
            {
                var jsSlot = new ProdutoHistoryData
                {
                    Id = change.Id == Guid.Empty.ToString() || change.Id == last.Id
                        ? ""
                        : change.Id,
                    Codigo = string.IsNullOrWhiteSpace(change.Codigo) || change.Codigo == last.Codigo
                        ? ""
                        : change.Codigo,
                    Nome = string.IsNullOrWhiteSpace(change.Nome) || change.Nome == last.Nome
                        ? ""
                        : change.Nome,
                    Preco = string.IsNullOrWhiteSpace(change.Preco) || change.Preco == last.Preco
                        ? ""
                        : change.Preco,
                    Quantidade = string.IsNullOrWhiteSpace(change.Quantidade) || change.Quantidade == last.Quantidade
                        ? ""
                        : change.Quantidade,
                    Action = string.IsNullOrWhiteSpace(change.Action) ? "" : change.Action,
                    Timestamp = change.Timestamp,
                    Who = change.Who
                };

                list.Add(jsSlot);
                last = change;
            }
            return list;
        }

        private static void ProdutoHistoryDeserializer(IEnumerable<HistoryEvent> storedEvents)
        {
            foreach (var e in storedEvents)
            {
                var historyData = JsonSerializer.Deserialize<ProdutoHistoryData>(e.Data);
                historyData.Timestamp = DateTime.Parse(historyData.Timestamp).ToString("yyyy'-'MM'-'dd' - 'HH':'mm':'ss");

                switch (e.MessageType)
                {
                    case "ProdutoRegisteredEvent":
                        historyData.Action = "Registered";
                        historyData.Who = e.User;
                        break;
                    case "ProdutoUpdatedEvent":
                        historyData.Action = "Updated";
                        historyData.Who = e.User;
                        break;
                    case "ProdutoRemovedEvent":
                        historyData.Action = "Removed";
                        historyData.Who = e.User;
                        break;
                    default:
                        historyData.Action = "Unrecognized";
                        historyData.Who = e.User ?? "Anonymous";
                        break;

                }
                HistoryData.Add(historyData);
            }
        }
    }
}