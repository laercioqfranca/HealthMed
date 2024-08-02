using HealthMed.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.ViewModels.Medico
{
    public class AgendaMedicaAgrupadoViewModel
    {
        public Guid IdMedico { get; set; }
        public List<AgendaViewModel> Agenda { get; set; }
    }
    public class AgendaViewModel()
    {
        public string Data { get; set; }
        public List<HorariosViewModel> Horarios { get; set; }
    }

    public class HorariosViewModel()
    {
        public string Horario { get; set; }
    }
}
