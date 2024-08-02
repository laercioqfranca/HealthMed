using FluentValidation;
using HealthMed.Domain.Commands.Medico;
using HealthMed.Domain.Commands.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Validations.Paciente
{
    public class AgendaPacienteCreateCommandValidation : CommandValidation<AgendaPacienteCreateCommand>
    {
        public AgendaPacienteCreateCommandValidation()
        {
            RuleFor(x => x.IdAgendaMedica)
                .NotNull().WithMessage("O IdAgendaMedica é obrigatório!");

            RuleFor(x => x.IdPaciente)
               .NotNull().WithMessage("O IdPaciente é obrigatório!");
        }
    }
}
