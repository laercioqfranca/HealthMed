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
    public class AgendaPacienteDeleteCommand : Command
    {
        public Guid IdAgendaMedica { get; protected set; }

        public AgendaPacienteDeleteCommand(Guid idAgendaMedica)
        {
            IdAgendaMedica = idAgendaMedica;
        }

        public override bool IsValid()
        {
            ValidationResult = new AgendaPacienteDeleteCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
