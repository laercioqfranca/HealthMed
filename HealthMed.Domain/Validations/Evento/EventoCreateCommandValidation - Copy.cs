using FluentValidation;
using HealthMed.Domain.Commands.Evento;

namespace HealthMed.Domain.Validations.Evento
{
    public class EventoCreateCommandValidation : CommandValidation<EventoCreateCommand>
    {
        public EventoCreateCommandValidation()
        {

            RuleFor(x => x.Descricao)
               .NotEmpty().WithMessage("A Descricao é obrigatória!");

            RuleFor(x => x.Data)
               .NotEmpty().WithMessage("A Data é obrigatória!");

        }
    }
}
