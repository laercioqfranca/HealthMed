using HealthMed.Core.Events;

namespace HealthMed.Core.Interfaces
{
    public interface IEventStore
    {
        void Save<T>(T theEvent) where T : Event;
    }
}
