using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Administracao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Commands
{
    public class AgendaPacienteCreateCommand : Command
    {
        public Guid IdAgendaMedica { get; protected set; }
        public Guid IdPaciente { get;  protected set; }

        public override bool IsValid()
        {
            //ValidationResult = new UsuarioCreateCommandValidation().Validate(this);
            return true;//ValidationResult.IsValid;
        }

    }
}
