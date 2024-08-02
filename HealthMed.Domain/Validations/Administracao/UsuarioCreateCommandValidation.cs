using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using HealthMed.Domain.Commands.Administracao;

namespace HealthMed.Domain.Validations.Administracao
{
    public class UsuarioCreateCommandValidation : CommandValidation<UsuarioCreateCommand>
    {
        public UsuarioCreateCommandValidation()
        {
            RuleFor(x => x.Nome)
                .NotEmpty().WithMessage("O Nome do usuário é obrigatório!");

            RuleFor(x => x.Email)
               .NotEmpty().WithMessage("O E-mail do usuário é obrigatório!");

            RuleFor(x => x.Senha)
               .NotEmpty().WithMessage("A Senha é obrigatória!")
               .Must(senha => senha.Length >= 8).WithMessage("A senha precisa conter no mínimo 8 caracteres");
        }
    }
}
