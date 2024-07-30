﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using HealthMed.Core.Interfaces;
using HealthMed.Application.DTO;
using HealthMed.Domain.Commands.Inscricao;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories;
using HealthMed.Application.Interfaces;
using HealthMed.Application.ViewModels;

namespace HealthMed.Application.AppServices
{
    public class SubscriptionAppService : ISubscriptionAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly ISubscriptionRepository _repository;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public SubscriptionAppService(IMapper mapper, IMediatorHandler bus, ISubscriptionRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
            _httpContextAcessor = httpContextAccessor;
        }

        public async Task<IEnumerable<EventoViewModel>> GetAllById(Guid id)
        {
            var query = await _repository.GetAllById(id);
            var evento = query.Select(x => x.Evento).OrderBy(x => x.Data);
            return _mapper.Map<IEnumerable<EventoViewModel>>(evento);
        }

        public async Task Create(SubscriptionDTO InscricaoDTO)
        {
            var command = _mapper.Map<SubscriptionCreateCommand>(InscricaoDTO);
            command.UsuarioRequerenteId = _httpContextAcessor.HttpContext.User.Identity.Name != null ? Guid.Parse(_httpContextAcessor.HttpContext.User.Identity.Name) : Guid.Parse("FEC63162-8B17-4CEC-8F1D-2BD181C43D67");
            await _bus.SendCommand(command);
        }

        public async Task Delete(Guid id)
        {
            var command = new SubscriptionDeleteCommand(id);
            command.UsuarioRequerenteId = _httpContextAcessor.HttpContext.User.Identity.Name != null ? Guid.Parse(_httpContextAcessor.HttpContext.User.Identity.Name) : Guid.Parse("FEC63162-8B17-4CEC-8F1D-2BD181C43D67");
            await _bus.SendCommand(command);

        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

    }
}
