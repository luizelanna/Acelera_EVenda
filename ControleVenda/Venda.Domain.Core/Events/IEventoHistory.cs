using NetDevPack.Messaging;

namespace Venda.Domain.Core.Events
{
    public interface IEventoHistory
    {
        void Save<T>(T evento) where T : Event;
    }
}
