﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HealthMed.Application.DTO;
using HealthMed.Application.ViewModels;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Domain.Enum;

namespace HealthMed.Application.Interfaces
{
    public interface IAgendaPacienteAppService
    {
        //Task<IEnumerable<AgendaMedicaViewModel>> GetByFilter(DateTime? data, Guid? idHorario, Guid? idMedico, Guid? idPaciente);
        Task Create(AgendaPacienteDTO agendaPacienteDTO);
    }
}
