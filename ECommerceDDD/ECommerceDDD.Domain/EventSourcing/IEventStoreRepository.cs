using ECommerceDDD.Domain.Events;

namespace ECommerceDDD.Domain.EventSourcing
{
    public interface IEventStoreRepository
    {
        void Save<TEvent>(TEvent theEvent) where TEvent : DomainEvent;
    }
}