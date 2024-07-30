﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces;
using HealthMed.Application.ViewModels;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Commands.Evento;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories;

namespace HealthMed.Application.AppServices
{
    public class EventoAppService : IEventoAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IEventoRepository _repository;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public EventoAppService(IMapper mapper, IMediatorHandler bus, IEventoRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
            _httpContextAcessor = httpContextAccessor;
        }

        public async Task<IEnumerable<EventoViewModel>> GetAll()
        {
            var query = await _repository.GetAll();
            var list = _mapper.Map<List<EventoViewModel>>(query);
            return list;

        }

        public async Task<EventoViewModel> GetById(Guid id)
        {
            var query = await _repository.GetById(id);
            return _mapper.Map<EventoViewModel>(query);
        }

        public async Task Create(EventoDTO eventoDTO)
        {
            var command = _mapper.Map<EventoCreateCommand>(eventoDTO);
            command.UsuarioRequerenteId = _httpContextAcessor.HttpContext.User.Identity.Name != null ? Guid.Parse(_httpContextAcessor.HttpContext.User.Identity.Name) : Guid.Parse("0368ED88-FF1F-4262-B33B-2599F5B47427");
            await _bus.SendCommand(command);
        }

        public async Task Update(EventoDTO eventoDTO)
        {
            var command = _mapper.Map<EventoUpdateCommand>(eventoDTO);
            command.UsuarioRequerenteId = _httpContextAcessor.HttpContext.User.Identity.Name != null ? Guid.Parse(_httpContextAcessor.HttpContext.User.Identity.Name) : Guid.Parse("0368ED88-FF1F-4262-B33B-2599F5B47427"); ;
            await _bus.SendCommand(command);
        }

        public async Task Delete(Guid id)
        {
            var command = new EventoDeleteCommand(id);
            command.UsuarioRequerenteId = _httpContextAcessor.HttpContext.User.Identity.Name != null ? Guid.Parse(_httpContextAcessor.HttpContext.User.Identity.Name) : Guid.Parse("0368ED88-FF1F-4262-B33B-2599F5B47427"); ;
            await _bus.SendCommand(command);

        }

    }

}