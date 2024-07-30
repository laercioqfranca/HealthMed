using System.Text.Json;
using HealthMed.Core.Events;
using HealthMed.Core.Interfaces;

namespace HealthMed.Infra.Data.EventSourcing
{
    public class EventStore : IEventStore
    {
        public void Save<T>(T theEvent) where T : Event
        {
            var serializedData = JsonSerializer.Serialize(theEvent);
            var storedEvent = new StoredEvent(theEvent, serializedData, "_user.Name");
        }
    }
}
