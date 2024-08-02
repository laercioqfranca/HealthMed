using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.ViewModels.Paciente;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Domain.Enum;

namespace HealthMed.Application.Interfaces.Paciente
{
    public interface IAgendaPacienteAppService
    {
        Task<IEnumerable<AgendaPacienteViewModel>> GetAll();
        Task Create(AgendaPacienteDTO agendaPacienteDTO);
        Task Delete(Guid idAgendaPaciente);
    }
}
