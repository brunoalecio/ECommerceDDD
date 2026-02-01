using System;

namespace ECommerceDDD.Infra.Data.EventSourcing
{
    public class StoredEvent
    {
        public Guid Id { get; private set; }
        public string Type { get; private set; }
        public DateTime OccurredOn { get; private set; }
        public string Data { get; private set; }

        // EF Core
        protected StoredEvent() { }

        public StoredEvent(Guid id, string type, string data)
        {
            Id = id;
            Type = type;
            Data = data;
            OccurredOn = DateTime.UtcNow;
        }
    }
}