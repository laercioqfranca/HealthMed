using HealthMed.Application.ViewModels.Medico;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Models.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.ViewModels.Paciente
{
    public class AgendaPacienteViewModel
    {
        public Guid IdAgendaMedica { get; set; }
        public Guid IdPaciente { get; set; }
        public string NomeMedico { get; set; }
        public DateTime DataConsulta { get; set; }
        public string HorarioConsulta { get; set; } 
        public string EspecialidadeMedica { get; set; }
       
    }
}
