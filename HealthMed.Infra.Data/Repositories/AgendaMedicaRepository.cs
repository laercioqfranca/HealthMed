using HealthMed.Domain.Interfaces.Infra.Data.Repositories;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Models;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;

namespace HealthMed.Infra.Data.Repositories
{
    public class AgendaMedicaRepository : Repository<AgendaMedica>, IAgendaMedicaRepository
    {
        private readonly HealthMedContext _context;

        public AgendaMedicaRepository(HealthMedContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
