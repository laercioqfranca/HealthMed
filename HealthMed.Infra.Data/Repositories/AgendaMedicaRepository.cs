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
    }
}
