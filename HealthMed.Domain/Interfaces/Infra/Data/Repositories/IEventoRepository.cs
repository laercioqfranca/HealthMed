using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Models;
using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories
{
    public interface IEventoRepository : IRepository<Eventos>
    {
        Task<IEnumerable<Eventos>> GetAll();
        Task<Eventos> GetById(Guid idEvento);
    }
}
