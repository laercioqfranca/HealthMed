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
        public Guid IdAgenda { get; protected set; }

        public AgendaMedicaDeleteCommand(Guid idAgenda)
        {
            IdAgenda = idAgenda;
        }

        public override bool IsValid()
        {
            ValidationResult = new AgendaMedicaDeleteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
