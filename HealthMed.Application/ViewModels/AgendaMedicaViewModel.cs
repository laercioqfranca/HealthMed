﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.ViewModels
{
    public class AgendaMedicaViewModel
    {
        public string NomeMedico { get; set; }
        public string NomePaciente { get; set; }
        public string DataConsulta { get; set; }
        public string HorarioConsulta { get; set; }
    }
}
