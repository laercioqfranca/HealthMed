using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Medico;
using HealthMed.Domain.Models.Medico;
using HealthMed.Domain.Models.Paciente;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;

namespace HealthMed.Infra.Data.Repositories.Medico
{
    public class AgendaMedicaRepository : Repository<AgendaMedica>, IAgendaMedicaRepository
    {
        private readonly HealthMedContext _dbContext;

        public AgendaMedicaRepository(HealthMedContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<AgendaMedica>> GetByFilter(DateTime? data, Guid? idHorario, Guid? idMedico, Guid? idPaciente)
        {
            return await DbSet
                .Include(x => x.Horario)
                .Include(x => x.Medico)
            .Where(x =>
            (data == null || x.Data.Date == data) &&
            (idHorario == null || x.IdHorario == idHorario) &&
            (idMedico == null || x.IdMedico == idMedico)
            ).AsNoTracking().ToListAsync();
        }

        public async Task<AgendaMedica?> GetById(Guid id, bool? agendado)
        {
            return await DbSet
                .Include(x => x.Horario)
                .Include(x => x.Medico)
            .Where(x =>
            x.Id == id &&
            (agendado == null || x.Agendado == agendado)
            ).AsNoTracking().SingleOrDefaultAsync();

        }
        public async Task<IEnumerable<AgendaMedica>> GetByDate(DateTime dataAgenda, bool? agendado)
        {
            return await DbSet
                .Include(x => x.Horario)
                .Include(x => x.Medico)
            .Where(x => 
            x.Data == dataAgenda &&
            (agendado == null || x.Agendado == agendado)
            ).AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<AgendaMedica>> GetListByIdMedico(Guid idMedico)
        {
            return await DbSet
                .Include(x => x.Horario)
                .Include(x => x.Medico)
            .Where(x => x.IdMedico == idMedico)
            .AsNoTracking().ToListAsync();

        }
    }
}
