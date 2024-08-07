﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HealthMed.Domain.Commands.Administracao;

namespace HealthMed.Domain.Validations.Administracao
{
    public class UsuarioUpdateCommandValidation : CommandValidation<UsuarioUpdateCommand>
    {
        public UsuarioUpdateCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome do usuário é obrigatório!");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("O E-mail do usuário é obrigatório!");

            RuleFor(x => x.IdPerfil)
               .NotEmpty().WithMessage("O Grupo de Acesso é obrigatório!");
        }
    }
}
