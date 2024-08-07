﻿using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Application.Interfaces.Paciente;
using HealthMed.Application.Interfaces.TabeleDominio;
using HealthMed.Application.ViewModels;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.ViewModels.Paciente;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Commands.Administracao;
using HealthMed.Domain.Commands.Paciente;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Paciente;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.TabelaDominio;
using Microsoft.AspNetCore.Http;

namespace HealthMed.Application.AppServices.Paciente
{
    public class AgendaPacienteAppService : IAgendaPacienteAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAgendaPacienteRepository _repository;

        public AgendaPacienteAppService(IMapper mapper, IMediatorHandler bus, IHttpContextAccessor httpContextAccessor, IAgendaPacienteRepository repository)
        {
            _mapper = mapper;
            _bus = bus;
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }

        public async Task<IEnumerable<AgendaPacienteViewModel>> GetAll()
        {
            var usuarios = await _repository.GetAll();
            return _mapper.Map<IEnumerable<AgendaPacienteViewModel>>(usuarios);
        }

        public async Task Create(AgendaPacienteDTO agendaPacienteDTO)
        {
            var command = _mapper.Map<AgendaPacienteCreateCommand>(agendaPacienteDTO);
            command.UsuarioRequerenteId = new Guid(_httpContextAccessor.HttpContext?.User.Identity.Name);
            await _bus.SendCommand(command);
        }
        public async Task Delete(Guid idAgendaMedica)
        {
            var command = new AgendaPacienteDeleteCommand(idAgendaMedica);
            command.UsuarioRequerenteId = new Guid(_httpContextAccessor.HttpContext?.User.Identity.Name);
            await _bus.SendCommand(command);
        }

    }

}
