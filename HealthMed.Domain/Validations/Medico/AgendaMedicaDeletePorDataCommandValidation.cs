using FluentValidation;
using HealthMed.Domain.Commands.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Validations.Paciente
{
    public class AgendaMedicaDeletePorDataCommandValidation : CommandValidation<AgendaMedicaDeletePorDataCommand>
    {
        public AgendaMedicaDeletePorDataCommandValidation()
        {
            RuleFor(x => x.DataAgenda)
                .NotNull().WithMessage("O DataAgenda é obrigatório!");
        }
    }
}
