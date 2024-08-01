using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Commands
{
    public class AgendaMedicaCreateCommand : Command
    {
        public Guid IdMedico { get; protected set; }
        public List<AgendaCreateCommand> Content { get; protected set; }
        public class AgendaCreateCommand()
        {
            public DateTime Data { get; protected set; }
            public Guid IdHorario { get; protected set; }
        }

        public override bool IsValid()
        {
            //ValidationResult = new UsuarioCreateCommandValidation().Validate(this);
            return true;//ValidationResult.IsValid;
        }

    }
}
