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
        public List<AgendaCreateCommand> Content { get; set; }
        public Guid IdMedico { get; set; }
        public class AgendaCreateCommand()
        {
            public DateTime Data { get; set; }
            public Guid IdHorario { get; set; }
        }

        public override bool IsValid()
        {
            //ValidationResult = new UsuarioCreateCommandValidation().Validate(this);
            return true;//ValidationResult.IsValid;
        }

    }
}
