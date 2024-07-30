using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Domain.Enum;

namespace HealthMed.Application.Interfaces.Auth
{
    public interface IPerfilUsuarioAppService
    {
        Task<IEnumerable<PerfilUsuarioViewModel>> GetPerfilUsuario(Guid? idPerfil, EnumTipoPerfil? tipoPerfil);
        Task<IEnumerable<PerfilUsuarioViewModel>> GetAll();
    }
}
