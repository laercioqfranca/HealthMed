using HealthMed.Domain.Models.Autenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Models
{
    public class AgendaPaciente
    {
        public Guid IdAgendaMedica { get; private set; }
        public Guid IdPaciente { get; private set; }
        public virtual AgendaMedica AgendaMedica { get; private set; }
        public virtual Usuario Paciente { get; private set; }
    }
}
