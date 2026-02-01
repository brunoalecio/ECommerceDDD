using MediatR;

namespace ECommerceDDD.Domain.Events
{
    public abstract class DomainEvent : INotification
    {
        public Guid Id { get; protected set; }
        public DateTime Timestamp { get; protected set; }

        protected DomainEvent()
        {
            Id = Guid.NewGuid();
            Timestamp = DateTime.UtcNow;
        }
    }
}