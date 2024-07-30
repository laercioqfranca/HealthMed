using FluentValidation;
using HealthMed.Domain.Commands.Inscricao;

namespace HealthMed.Domain.Validations.Inscricao
{
    public class InscricaoCommandValidation : CommandValidation<SubscriptionCreateCommand>
    {
        public InscricaoCommandValidation()
        {
            RuleFor(x => x.IdEvento)
               .NotEmpty().WithMessage("O Evento é obrigatório!");
        }
    }
}
