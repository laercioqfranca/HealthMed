using AutoMapper;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces.Medico;
using HealthMed.Application.ViewModels.Medico;
using HealthMed.Core.Interfaces;
using HealthMed.Domain.Commands.Medico;
using HealthMed.Domain.Commands.Paciente;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Medico;
using Microsoft.AspNetCore.Http;

namespace HealthMed.Application.AppServices.Medico
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
        public async Task<IEnumerable<AgendaMedicaViewModel>> GetByFilter(AgendaMedicaFiltroViewModel filtro)
        {
            var query = await _repository.GetByFilter(filtro.Data, filtro.IdHorario, filtro.IdMedico, filtro.IdPaciente);
            var list = _mapper.Map<List<AgendaMedicaViewModel>>(query);
            return list;

        }

        public async Task<AgendaMedicaAgrupadoViewModel> GetListByIdMedico(Guid idMedico)
        {
            var query = await _repository.GetListByIdMedico(idMedico);
            var result = new AgendaMedicaAgrupadoViewModel
            {
                IdMedico = idMedico,
                Agenda = query.GroupBy(x => x.Data.Date).SelectMany(x => new List<AgendaViewModel>
                {
                    new AgendaViewModel {
                        Data = x.Key.ToString("dd/MM/yyyy"),
                        Horarios = x.SelectMany(y => new List<HorariosViewModel> {
                         new HorariosViewModel {
                             Id = y.IdHorario,
                             IdAgenda = y.Id,
                             Horario = y.Horario.Descricao,
                             Agendado = y.Agendado
                         }
                        }).OrderBy(x => x.Horario).ToList()
                    }
                }).OrderBy(x => x.Data).ToList()

            };
            return result;
        }

        public async Task Create(AgendaMedicaDTO agendaMedicaDTO)
        {
            var command = _mapper.Map<AgendaMedicaCreateCommand>(agendaMedicaDTO);
            command.UsuarioRequerenteId = new Guid(_httpContextAccessor.HttpContext?.User.Identity.Name);
            await _bus.SendCommand(command);
        }

        public async Task DeletePorData(DateTime dataAgenda)
        {
            var command = new AgendaMedicaDeletePorDataCommand(dataAgenda);
            command.UsuarioRequerenteId = new Guid(_httpContextAccessor.HttpContext?.User.Identity.Name);
            await _bus.SendCommand(command);
        }
        public async Task Delete(Guid iAgenda)
        {
            var command = new AgendaMedicaDeleteCommand(iAgenda);
            command.UsuarioRequerenteId = new Guid(_httpContextAccessor.HttpContext?.User.Identity.Name);
            await _bus.SendCommand(command);
        }

    }

}
