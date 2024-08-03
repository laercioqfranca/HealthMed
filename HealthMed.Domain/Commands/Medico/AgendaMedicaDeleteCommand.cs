using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Administracao;
using HealthMed.Domain.Validations.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Commands.Paciente
{
    public class AgendaMedicaDeleteCommand : Command
    {
        public DateTime DataAgenda { get; protected set; }

        public AgendaMedicaDeleteCommand(DateTime dataAgenda)
        {
            DataAgenda = dataAgenda;
        }

        public override bool IsValid()
        {
            ValidationResult = new AgendaMedicaDeleteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
