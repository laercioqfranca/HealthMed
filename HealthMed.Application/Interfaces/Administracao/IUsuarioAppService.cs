using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels.Administracao;
using HealthMed.Application.ViewModels.Auth;

namespace HealthMed.Application.Interfaces.Administracao
{
    public interface IUsuarioAppService : IDisposable
    {
        Task<PacienteViewModel> GetById(Guid id);
        Task<PacienteViewModel> GetByLogin(string login);
        Task<IEnumerable<PacienteViewModel>> GetByFiltro(ConsultarPorFiltroViewModel filtro);
        Task<IEnumerable<PacienteViewModel>> GetAll();
        Task<IEnumerable<UsuarioMedicoViewModel>> GetListByIdEspecialidade(Guid idEspecialidade);
        Task Create(UsuarioDTO usuarioDTO);
        Task Update(PacienteViewModel model);
        Task Delete(Guid id);

    }
}
