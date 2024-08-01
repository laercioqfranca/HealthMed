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
    public class AgendaMedicaCommandHandler : CommandHandler, IRequestHandler<AgendaMedicaCreateCommand>
    {

        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private readonly IAgendaMedicaRepository _repository;

        public AgendaMedicaCommandHandler(IAgendaMedicaRepository repository,
            IMediatorHandler bus,
            IUnitOfWork uow,
            INotificationHandler<DomainNotification> notifications)
            : base(uow, bus, notifications)
        {
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
            _repository = repository;
        }

        public async Task<Unit> Handle(AgendaMedicaCreateCommand request, CancellationToken cancellationToken)
        {
            LogHistorico log = new LogHistorico();

            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {
                List<AgendaMedica> agendaMedicas = new List<AgendaMedica>();
                agendaMedicas = request.Content.Select(x => new AgendaMedica(x.Data, x.IdHorario, request.UsuarioRequerenteId.Value, null)).ToList();
                _repository.AddList(agendaMedicas);
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
    }
}
