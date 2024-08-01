using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Application.Interfaces.TabeleDominio;
using HealthMed.Application.ViewModels;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Commands;
using HealthMed.Domain.Commands.Administracao;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.TabelaDominio;
using Microsoft.AspNetCore.Http;

namespace HealthMed.Application.AppServices
{
    public class AgendaMedicaAppService : IAgendaMedicaAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private readonly IAgendaMedicaRepository _repository;

        public AgendaMedicaAppService(IMapper mapper, IMediatorHandler bus, IHttpContextAccessor httpContextAccessor, IAgendaMedicaRepository repository)
        {
            _mapper = mapper;
            _bus = bus;
            _httpContextAccessor = httpContextAccessor;
            _repository = repository;
        }
        public async Task<IEnumerable<AgendaMedicaViewModel>> GetByFilter(DateTime? data, Guid? idHorario, Guid? idMedico, Guid? idPaciente)
        {
            var query = await _repository.GetByFilter(data, idHorario, idMedico, idPaciente);
            var list = _mapper.Map<List<AgendaMedicaViewModel>>(query);
            return list;

        }

        public async Task Create(AgendaMedicaDTO agendaMedicaDTO)
        {
            var command = _mapper.Map<AgendaMedicaCreateCommand>(agendaMedicaDTO);
            command.UsuarioRequerenteId = new Guid(_httpContextAccessor.HttpContext?.User.Identity.Name);
            await _bus.SendCommand(command);
        }

    }

}
