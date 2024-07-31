using System;
using System.Collections.Generic;
using System.Security.Claims;
using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Application.Interfaces.TabeleDominio;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Commands;
using HealthMed.Domain.Commands.Administracao;
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

        public AgendaMedicaAppService(IMapper mapper, IMediatorHandler bus, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _bus = bus;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task Create(AgendaMedicaDTO agendaMedicaDTO)
        {
            var command = _mapper.Map<AgendaMedicaCreateCommand>(agendaMedicaDTO);
            command.UsuarioRequerenteId = new Guid(_httpContextAccessor.HttpContext?.User.Claims.Single(c => c.Type == "UsuarioID").ToString());
            await _bus.SendCommand(command);
        }

    }

}
