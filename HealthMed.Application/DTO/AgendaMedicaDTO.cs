using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.DTO
{
    public class AgendaMedicaDTO
    {
        public Guid IdMedico { get; set; }
        public List<AgendaDTO> Content { get; set; }

    }
    public class AgendaDTO()
    {
        public DateTime Data { get; set; }
        public Guid IdHorario { get; set; }
    }
}

