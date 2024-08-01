using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Administracao;

namespace HealthMed.Domain.Commands.Administracao
{
    public class UsuarioCreateCommand : Command
    {
        public UsuarioCreateCommand() { }

        public string Nome { get; protected set; }
        public string Email { get; protected set; }
        public string Senha { get; protected set; }
        public string? CRM { get; protected set; }

        public Guid? IdPerfil { get; protected set; }
        public Guid? IdEspecialidade { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new UsuarioCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
