﻿using HealthMed.Domain.Enum;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.TabelaDominio;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.TabelaDominio;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Infra.Data.Repositories.TabelaDominio
{
    public class HorarioRepository : Repository<Horario>, IHorarioRepository
    {
        public HorarioRepository(HealthMedContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<Horario>> GetAll()
        {
            return await DbSet.Where(x => !x.Excluido).AsNoTracking().ToListAsync();
        }
    }
}
