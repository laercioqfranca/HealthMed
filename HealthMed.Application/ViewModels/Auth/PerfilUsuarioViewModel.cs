﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Domain.Enum;

namespace HealthMed.Application.ViewModels.Auth
{
    public class PerfilUsuarioViewModel
    {
        public Guid Id { get; set; }
        public string Perfil { get; set; }
        public string Descricao { get; set; }
        public int IdTipoPerfil { get; set; }
    }

}
