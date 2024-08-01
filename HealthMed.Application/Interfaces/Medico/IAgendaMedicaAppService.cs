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

namespace HealthMed.Application.Interfaces.Medico
{
    public interface IAgendaMedicaAppService
    {
        Task<IEnumerable<AgendaMedicaViewModel>> GetByFilter(AgendaMedicaFiltroViewModel filtro);
        Task Create(AgendaMedicaDTO agendaMedicaDTO);
    }
}