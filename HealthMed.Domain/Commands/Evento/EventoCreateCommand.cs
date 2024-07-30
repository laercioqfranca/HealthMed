using System;
using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Evento;

namespace HealthMed.Domain.Commands.Evento
{
    public class EventoCreateCommand : Command
    {
        public EventoCreateCommand() { }
        public Guid Id { get; set; }
        public string Descricao { get; protected set; }
        public DateTime Data { get; protected set; }

        public override bool IsValid()
        {
            ValidationResult = new EventoCreateCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }

    }
}
