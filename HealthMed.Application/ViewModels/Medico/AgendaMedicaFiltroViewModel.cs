using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.ViewModels.Medico
{
    public class AgendaMedicaFiltroViewModel
    {
        public DateTime? Data { get; set; }
        public Guid? IdHorario { get; set; }
        public Guid? IdMedico { get; set; }
        public Guid? IdPaciente { get; set; }

    }
}
