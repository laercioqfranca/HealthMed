using HealthMed.Domain.Commands.Administracao;
using HealthMed.Domain.Commands.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Validations.Medico
{
    public class AgendaMedicaCreateCommandValidation : CommandValidation<AgendaMedicaCreateCommand>
    {
        public AgendaMedicaCreateCommandValidation()
        {
        }
    }
}
