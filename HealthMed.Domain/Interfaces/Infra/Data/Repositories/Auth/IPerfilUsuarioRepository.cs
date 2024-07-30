using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Models.Autenticacao;

namespace HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth
{
    public interface IPerfilUsuarioRepository
    {
        Task<IEnumerable<PerfilUsuario>> GetPerfilUsuario(EnumTipoPerfil? tipoPerfil);
        Task<IEnumerable<PerfilUsuario>> GetAll();
    }
}
