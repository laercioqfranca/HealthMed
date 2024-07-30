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
    public class SubscriptionRepository : Repository<Subscription>, ISubscriptionRepository
    {
        private readonly HealthMedContext _context;

        public SubscriptionRepository(HealthMedContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Subscription>> GetAllById(Guid idUsuario)
        {
            var inscricoes = await _context.Set<Subscription>()
                .Include(x => x.Evento)
                .Where(
                    x => x.IdUsuario == idUsuario && !x.Evento.Excluido
            ).ToListAsync();
            return inscricoes;
        }

        public async Task<Subscription> GetById(Guid idUsuario, Guid idEvento)
        {
            var inscricao = await _context.Set<Subscription>()
                .Where(
                    x => x.IdUsuario == idUsuario && x.IdEvento == idEvento 
            ).FirstOrDefaultAsync();
            return inscricao;
        }

    }
}
