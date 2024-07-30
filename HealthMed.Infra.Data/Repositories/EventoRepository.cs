using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories;
using HealthMed.Domain.Models;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;

namespace HealthMed.Infra.Data.Repositories
{
    public class EventoRepository : Repository<Eventos>, IEventoRepository
    {
        private readonly HealthMedContext _context;
        public EventoRepository(HealthMedContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Eventos>> GetAll()
        {
            IQueryable<Eventos> query = DbSet.Where(x => !x.Excluido).OrderByDescending(x => x.Data);
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<Eventos> GetById(Guid idEvento)
        {
            var evento = await _context.Set<Eventos>()
                .Where(
                    x => x.Id == idEvento //&& !x.Excluido
            ).FirstOrDefaultAsync();
            return evento;
        }
    }
}
