using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Administracao;
using HealthMed.Domain.Validations.Medico;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Commands.Medico
{
    public class AgendaMedicaCreateCommand : Command
    {
        //public Guid IdMedico { get; protected set; }
        public List<AgendaCreateCommand> Content { get; protected set; }
        public class AgendaCreateCommand()
        {
            public DateTime Data { get; protected set; }
            public Guid IdHorario { get; protected set; }
        }

        public override bool IsValid()
        {
            ValidationResult = new AgendaMedicaCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
