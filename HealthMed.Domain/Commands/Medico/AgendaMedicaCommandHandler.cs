using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Domain.Models.Administracao;
using MediatR;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Medico;
using HealthMed.Domain.Models.Medico;
using HealthMed.Domain.Commands.Paciente;
using HealthMed.Domain.Models.Paciente;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Paciente;
using MassTransit.Middleware;

namespace HealthMed.Domain.Commands.Medico
{
    public class AgendaMedicaCommandHandler : CommandHandler, IRequestHandler<AgendaMedicaCreateCommand>, 
        IRequestHandler<AgendaMedicaDeleteCommand>, IRequestHandler<AgendaMedicaDeletePorDataCommand>
    {

        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private readonly IAgendaMedicaRepository _iAgendaMedicaRepository;
        private readonly IAgendaPacienteRepository _iAgendaPacienteRepository;

        public AgendaMedicaCommandHandler(
            IAgendaMedicaRepository repository,
            IAgendaPacienteRepository iAgendaPacienteRepository,
            IMediatorHandler bus,
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
            _iAgendaMedicaRepository = repository;
            _iAgendaPacienteRepository = iAgendaPacienteRepository;
        }

        public async Task<Unit> Handle(AgendaMedicaCreateCommand request, CancellationToken cancellationToken)
        {
            LogHistorico log = new LogHistorico();

            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {
                List<AgendaMedica> agendaMedicas = new List<AgendaMedica>();
                agendaMedicas = request.Content.Select(x => new AgendaMedica(x.Data, x.IdHorario, request.UsuarioRequerenteId.Value)).ToList();
                _iAgendaMedicaRepository.AddList(agendaMedicas);
            }

            var notificationsString = _notifications.HasNotifications() ? string.Join(";", _notifications.GetNotifications().Select(x => x.Value)) : null;

            if (notificationsString == null)
            {
                log = new LogHistorico(Guid.NewGuid(), Guid.NewGuid(), EnumTipoLog.CREATE, "AgendaMedica", $"Agenda Medica created");
            }
            else
            {
                log = log.SaveLogHistorico(EnumTipoLog.CREATE, "AgendaMedica", "Error", notificationsString);
            }

            if (_notifications.HasNotifications()) await Commit(true);
            if (!_notifications.HasNotifications()) await Commit();

            return Unit.Value;
        }

        public async Task<Unit> Handle(AgendaMedicaDeletePorDataCommand request, CancellationToken cancellationToken)
        {
            LogHistorico log = new LogHistorico();
            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {
                var agendaMedica = await _iAgendaMedicaRepository.GetByDate(request.DataAgenda, null);

                if (agendaMedica.Any())
                {     
                    foreach(AgendaMedica agenda in agendaMedica)
                    {
                        AgendaMedica novaAgenda = new AgendaMedica(agenda.Data, agenda.IdHorario, agenda.IdMedico);
                        novaAgenda.Id = agenda.Id;

                        AgendaPaciente queryPaciente = await _iAgendaPacienteRepository.GetById(agenda.Id);

                        if (queryPaciente != null)
                        {
                            AgendaPaciente agendaPaciente = new AgendaPaciente(novaAgenda.Id, queryPaciente.IdPaciente);
                            _iAgendaPacienteRepository.Remove(agendaPaciente);
                        }
                        _iAgendaMedicaRepository.Remove(novaAgenda);
                    }
                }
                else
                {
                    await _bus.RaiseEvent(new DomainNotification("Agendamento", "Agendamento não encontrado!."));
                    return Unit.Value;
                }
            }

            var notificationsString = _notifications.HasNotifications() ? string.Join(";", _notifications.GetNotifications().Select(x => x.Value)) : null;

            if (notificationsString == null)
            {
                log = new LogHistorico(request.UsuarioRequerenteId, Guid.NewGuid(), EnumTipoLog.DELETE, "AgendaMedica", $"Agenda Médica deleted");
            }
            else
            {
                log = log.SaveLogHistorico(EnumTipoLog.DELETE, "AgendaMedica", "Error", notificationsString);
            }

            if (_notifications.HasNotifications()) await Commit(true);
            if (!_notifications.HasNotifications()) await Commit();

            return Unit.Value;
        }

        public async Task<Unit> Handle(AgendaMedicaDeleteCommand request, CancellationToken cancellationToken)
        {
            LogHistorico log = new LogHistorico();
            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {
                var queryAgenda = await _iAgendaMedicaRepository.GetById(request.IdAgenda, null);

                if (queryAgenda != null)
                {

                    AgendaMedica agenda = new AgendaMedica(queryAgenda.Data, queryAgenda.IdHorario, queryAgenda.IdMedico);
                    agenda.Id = queryAgenda.Id;

                    AgendaPaciente queryPaciente = await _iAgendaPacienteRepository.GetById(queryAgenda.Id);

                    if (queryPaciente != null)
                    {
                        AgendaPaciente agendaPaciente = new AgendaPaciente(agenda.Id, queryPaciente.IdPaciente);
                        _iAgendaPacienteRepository.Remove(agendaPaciente);
                    }

                    _iAgendaMedicaRepository.Remove(agenda);

                }
                else
                {
                    await _bus.RaiseEvent(new DomainNotification("Agendamento", "Agendamento não encontrado!."));
                    return Unit.Value;
                }
            }

            var notificationsString = _notifications.HasNotifications() ? string.Join(";", _notifications.GetNotifications().Select(x => x.Value)) : null;

            if (notificationsString == null)
            {
                log = new LogHistorico(request.UsuarioRequerenteId, Guid.NewGuid(), EnumTipoLog.DELETE, "AgendaMedica", $"Agenda Médica deleted");
            }
            else
            {
                log = log.SaveLogHistorico(EnumTipoLog.DELETE, "AgendaMedica", "Error", notificationsString);
            }

            if (_notifications.HasNotifications()) await Commit(true);
            if (!_notifications.HasNotifications()) await Commit();

            return Unit.Value;
        }
    }
}
