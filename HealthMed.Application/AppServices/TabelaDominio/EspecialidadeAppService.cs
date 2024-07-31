using System;
using System.Collections.Generic;
using AutoMapper;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Application.Interfaces.TabeleDominio;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.TabelaDominio;

namespace HealthMed.Application.AppServices.TabelaDominio
{
    public class EspecialidadeAppService : IEspecialidadeAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IEspecialidadeRepository _repository;

        public EspecialidadeAppService(IMapper mapper, IMediatorHandler bus, IEspecialidadeRepository repository)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
        }

        public async Task<IEnumerable<EspecialidadeViewModel>> GetAll()
        {
            var query = await _repository.GetAll();
            var list = _mapper.Map<List<EspecialidadeViewModel>>(query);
            return list;

        }

    }

}
