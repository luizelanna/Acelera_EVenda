using NetDevPack.Messaging;

namespace Estoque.Domain.Core.Events
{
    public interface IEventoHistory
    {
        void Save<T>(T evento) where T : Event;
    }
}
