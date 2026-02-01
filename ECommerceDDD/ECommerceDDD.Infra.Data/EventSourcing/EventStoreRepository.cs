using System.Text.Json;
using ECommerceDDD.Domain.Events;
using ECommerceDDD.Domain.EventSourcing;
using ECommerceDDD.Infra.Data.Context;
using Microsoft.Extensions.Logging;

namespace ECommerceDDD.Infra.Data.EventSourcing
{
    public class EventStoreRepository : IEventStoreRepository
    {
        private readonly ECommerceDbContext _context;

        public EventStoreRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        public void Save<TEvent>(TEvent theEvent) where TEvent : DomainEvent
        {
            var serializedData = JsonSerializer.Serialize(theEvent);

            var storedEvent = new StoredEvent(
                theEvent.Id,
                theEvent.GetType().Name,
                serializedData
            );

            _context.StoredEvents.Add(storedEvent);
        }
    }
}