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
    public class AgendaPacienteCreateCommand : Command
    {
        public Guid IdAgendaMedica { get; protected set; }
        public Guid IdPaciente { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new AgendaPacienteCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
