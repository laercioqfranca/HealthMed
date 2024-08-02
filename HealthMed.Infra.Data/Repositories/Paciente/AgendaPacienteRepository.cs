using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Paciente;
using HealthMed.Domain.Models.Medico;
using HealthMed.Domain.Models.Paciente;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Infra.Data.Repositories.Paciente
{
    public class AgendaPacienteRepository : Repository<AgendaPaciente>, IAgendaPacienteRepository
    {
        private readonly HealthMedContext _dbContext;

        public AgendaPacienteRepository(HealthMedContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AgendaPaciente?> GetById(Guid idAgendaMedica)
        {
            return await DbSet
                .Include(x => x.Paciente)
                .Include(x => x.AgendaMedica)
            .Where(x =>
            x.IdAgendaMedica == idAgendaMedica
            ).AsNoTracking().SingleOrDefaultAsync();

        }

        public async Task<IEnumerable<AgendaPaciente>> GetAll()
        {
            var query = await DbSet
                .Include(x => x.AgendaMedica)
                .ThenInclude(x => x.Medico)

                .Include(x => x.AgendaMedica)
                .ThenInclude(x => x.Horario)

                .Include(x => x.Paciente)
            .AsNoTracking().ToListAsync();

            return query;
        }
    }
}
