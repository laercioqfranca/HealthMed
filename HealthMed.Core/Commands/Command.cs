using FluentValidation.Results;
using HealthMed.Core.Events;
using System;

namespace HealthMed.Core.Commands
{
    public abstract class Command : Message
    {

        public Guid? UsuarioRequerenteId { get; set; }
        public DateTime Timestamp { get; private set; }
        public ValidationResult ValidationResult { get; set; }

        protected Command() => Timestamp = DateTime.Now;

        public abstract bool IsValid();

    }
}
