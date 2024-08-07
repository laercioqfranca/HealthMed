﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Core.Commands;
using HealthMed.Domain.Validations.Auth;

namespace HealthMed.Domain.Commands.Auth
{
    public class AutenticarCommand : Command
    {
        public string Login { get; protected set; }
        public string Senha { get; protected set; }

        public AutenticarCommand(string login, string senha)
        {
            Login = login;
            Senha = senha;
        }

        public override bool IsValid()
        {
            ValidationResult = new AutenticarCommandValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
