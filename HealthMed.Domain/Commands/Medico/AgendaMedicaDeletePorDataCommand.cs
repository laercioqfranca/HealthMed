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
    public class AgendaMedicaDeletePorDataCommand : Command
    {
        public DateTime DataAgenda { get; protected set; }

        public AgendaMedicaDeletePorDataCommand(DateTime dataAgenda)
        {
            DataAgenda = dataAgenda;
        }

        public override bool IsValid()
        {
            ValidationResult = new AgendaMedicaDeletePorDataCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
