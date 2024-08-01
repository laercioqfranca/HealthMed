using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Domain.Models.Administracao;
using HealthMed.Domain.Models.Autenticacao;
using MediatR;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories;
using HealthMed.Domain.Models;

namespace HealthMed.Domain.Commands
{
    public class AgendaPacienteCommandHandler : CommandHandler, IRequestHandler<AgendaPacienteCreateCommand>
    {

        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private readonly IAgendaPacienteRepository _repository;
        private readonly IAgendaMedicaRepository _repositoryAM;

        public AgendaPacienteCommandHandler(IAgendaPacienteRepository repository,
            IAgendaMedicaRepository repositoryAM,
            IMediatorHandler bus,
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
            _repository = repository;
            _repositoryAM = repositoryAM;
        }

        public async Task<Unit> Handle(AgendaPacienteCreateCommand request, CancellationToken cancellationToken)
        {
            LogHistorico log = new LogHistorico();

            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {
                AgendaMedica? agendaMedica = await _repositoryAM.GetById(request.IdAgendaMedica, null);
                if (agendaMedica?.Agendado == false)
                {
                    AgendaPaciente agendaPaciente = new AgendaPaciente(request.IdAgendaMedica, request.IdPaciente);
                    _repository.Add(agendaPaciente);
                    agendaMedica.setAgendado(true);
                    _repositoryAM.Update(agendaMedica);
                }
                else
                {
                    await _bus.RaiseEvent(new DomainNotification("Agendamento indisponível", "O Horário indisponível!."));
                    return Unit.Value;
                }
            }

            var notificationsString = _notifications.HasNotifications() ? string.Join(";", _notifications.GetNotifications().Select(x => x.Value)) : null;

            if (notificationsString == null)
            {
                log = new LogHistorico(Guid.NewGuid(), Guid.NewGuid(), EnumTipoLog.CREATE, "AgendaPaciente", $"Agenda Paciente created");
            }
            else
            {
                log = log.SaveLogHistorico(EnumTipoLog.CREATE, "AgendaPaciente", "Error", notificationsString);
            }

            if (_notifications.HasNotifications()) await Commit(true);
            if (!_notifications.HasNotifications()) await Commit();

            return Unit.Value;
        }
    }
}
