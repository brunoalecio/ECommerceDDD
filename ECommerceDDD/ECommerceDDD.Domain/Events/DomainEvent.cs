using MediatR;

namespace ECommerceDDD.Domain.Events
{
    public abstract class DomainEvent : INotification
    {
        public Guid AggregateId { get; protected set; }
        public DateTime Timestamp { get; private set; }

        protected DomainEvent(Guid aggregateId)
        {
            AggregateId = aggregateId;
            Timestamp = DateTime.UtcNow;
        }
    }
}
