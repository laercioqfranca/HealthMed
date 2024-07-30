using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels;

namespace HealthMed.Application.Interfaces
{
    public interface ISubscriptionAppService : IDisposable
    {
        Task<IEnumerable<EventoViewModel>> GetAllById(Guid id);
        Task Create(SubscriptionDTO inscricaoDTO);
        Task Delete(Guid id);

    }
}
