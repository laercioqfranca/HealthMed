using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;

namespace HealthMed.Infra.Data.Repositories.Auth
{
    public class PerfilUsuarioRepository : Repository<PerfilUsuario>, IPerfilUsuarioRepository
    {
        public PerfilUsuarioRepository(HealthMedContext dbContext) : base(dbContext)
        {
        }

        public async Task<IEnumerable<PerfilUsuario>> GetPerfilUsuario(EnumTipoPerfil? tipoPerfil)
        {
            IQueryable<PerfilUsuario> query = DbSet.Where(p =>
                                            (!p.Excluido) &&
                                                ((tipoPerfil == EnumTipoPerfil.Medico ) ||
                                                    (tipoPerfil == EnumTipoPerfil.Paciente))
                                                ).OrderBy(x => x.Descricao);
            return await query.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<PerfilUsuario>> GetAll()
        {
            IQueryable<PerfilUsuario> query = DbSet.Where(p => (!p.Excluido)).OrderBy(x => x.Descricao);
            return await query.AsNoTracking().ToListAsync();
        }
    }
}
