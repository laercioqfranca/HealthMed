using AutoMapper;
using HealthMed.Application.Interfaces.TabeleDominio;
using HealthMed.Application.ViewModels.TabelaDominio;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.TabelaDominio;

namespace HealthMed.Application.AppServices.TabelaDominio
{
    public class HorarioAppService : IHorarioAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly IHorarioRepository _repository;

        public HorarioAppService(IMapper mapper, IMediatorHandler bus, IHorarioRepository repository)
        {
            _mapper = mapper;
            _bus = bus;
            _repository = repository;
        }

        public async Task<IEnumerable<HorarioViewModel>> GetAll()
        {
            var query = await _repository.GetAll();
            var list = _mapper.Map<List<HorarioViewModel>>(query);
            return list;

        }

    }

}
