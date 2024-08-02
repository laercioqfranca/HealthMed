using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Infra.Data.Configuration;
using HealthMed.Infra.Data.Context;

namespace HealthMed.Infra.Data.Repositories.Auth
{
    public class UsuarioRepository : Repository<Usuario>, IUsuarioRepository
    {
        private readonly HealthMedContext _context;

        public UsuarioRepository(HealthMedContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }

        public async Task<IEnumerable<Usuario>> GetAll()
        {
            return await _context.Set<Usuario>()
                .Include(x => x.Perfil)
                .Where(x => !x.Excluido)
                .OrderByDescending(x => x.DataInclusao)
                .ToListAsync();
        }

        public async Task<IEnumerable<Usuario>> GetByLogin(string login)
        {
            return await _context.Set<Usuario>()
                 .Include(x => x.Perfil)
                .Where(x => x.Login.ToLower() == login.ToLower()
                    && !x.Excluido
                )
                .ToListAsync();
        }

        public async Task<Usuario> GetById(Guid id)
        {
            Usuario usuario = await _context.Set<Usuario>()
                .Include(u => u.Perfil)
                .Where(
                    u => !u.Excluido && 
                    u.Id == id
            ).FirstOrDefaultAsync();
            return usuario;
        }

        public async Task<List<Usuario>> GetListByIdEspecialidade(Guid idEspecialidade)
        {
            List<Usuario> usuarios = await _context.Set<Usuario>()
                .Include(u => u.Especialidade)
                .Where(
                    u => (!u.Excluido) &&
                    (u.IdEspecialidade == idEspecialidade)
            ).AsNoTracking().ToListAsync();
            return usuarios;
        }

        public async Task<IEnumerable<Usuario>> GetByFiltro(string nome, string cpf, string email)
        {
            var usuarios =  await _context.Set<Usuario>()
                .Include(x => x.Perfil)
                .Where(
                x => !x.Excluido &&
                (nome == null || x.Nome == nome) &&
                (email == null || x.Email == email)
            )
            .ToListAsync();

            return usuarios;

        }

    }
}
