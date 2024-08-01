using HealthMed.Domain.Interfaces.Infra.Data.Repositories;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Models;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.TabelaDominio;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Infra.Data.Repositories
{
    public class AgendaPacienteRepository : Repository<AgendaPaciente>, IAgendaPacienteRepository
    {
        private readonly HealthMedContext _dbContext;

        public AgendaPacienteRepository(HealthMedContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
    }
}
