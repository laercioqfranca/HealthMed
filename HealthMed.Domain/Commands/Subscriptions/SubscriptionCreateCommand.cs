using System;
using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Inscricao;

namespace HealthMed.Domain.Commands.Inscricao
{
    public class SubscriptionCreateCommand : Command
    {
        public SubscriptionCreateCommand() { }
        public Guid IdEvento { get; protected set; }


        public override bool IsValid()
        {
            ValidationResult = new InscricaoCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
