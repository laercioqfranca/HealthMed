using System;
using System.Threading.Tasks;

namespace HealthMed.Domain.Interfaces.Infra.Data
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> Commit();
    }
}
