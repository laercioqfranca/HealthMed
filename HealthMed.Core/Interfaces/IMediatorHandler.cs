using HealthMed.Core.Commands;
using HealthMed.Core.Events;
using System.Threading.Tasks;

namespace HealthMed.Core.Interfaces
{
    public interface IMediatorHandler
    {
        Task SendCommand<T>(T command) where T : Command;
        Task RaiseEvent<T>(T @event) where T : Event;
    }
}
