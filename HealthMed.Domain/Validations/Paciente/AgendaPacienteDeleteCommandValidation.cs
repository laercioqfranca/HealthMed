﻿using FluentValidation;
using HealthMed.Domain.Commands.Paciente;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Domain.Validations.Paciente
{
    public class AgendaPacienteDeleteCommandValidation : CommandValidation<AgendaPacienteDeleteCommand>
    {
        public AgendaPacienteDeleteCommandValidation()
        {
            RuleFor(x => x.IdAgendaMedica)
                .NotNull().WithMessage("O IdAgendaMedica é obrigatório!");

        }
    }
}
