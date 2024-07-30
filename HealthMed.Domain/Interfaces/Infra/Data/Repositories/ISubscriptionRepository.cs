using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HealthMed.Domain.Models;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories
{
    public interface ISubscriptionRepository : IRepository<Subscription>
    {
        Task<IEnumerable<Subscription>> GetAllById(Guid idUsuario);
        Task<Subscription> GetById(Guid idUsuario, Guid idEvento);
    }
}
