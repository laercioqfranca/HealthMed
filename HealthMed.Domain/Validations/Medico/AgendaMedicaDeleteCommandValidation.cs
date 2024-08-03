using FluentValidation;
using HealthMed.Domain.Commands.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Validations.Paciente
{
    public class AgendaMedicaDeleteCommandValidation : CommandValidation<AgendaMedicaDeleteCommand>
    {
        public AgendaMedicaDeleteCommandValidation()
        {
            RuleFor(x => x.IdAgenda)
                .NotNull().WithMessage("O IdAgenda é obrigatório!");
        }
    }
}
