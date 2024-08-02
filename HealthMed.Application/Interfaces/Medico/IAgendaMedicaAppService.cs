using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels.Medico;

namespace HealthMed.Application.Interfaces.Medico
{
    public interface IAgendaMedicaAppService
    {
        Task<IEnumerable<AgendaMedicaViewModel>> GetByFilter(AgendaMedicaFiltroViewModel filtro);
        Task<AgendaMedicaAgrupadoViewModel> GetListByIdMedico(Guid idMedico);
        Task Create(AgendaMedicaDTO agendaMedicaDTO);
    }
}
