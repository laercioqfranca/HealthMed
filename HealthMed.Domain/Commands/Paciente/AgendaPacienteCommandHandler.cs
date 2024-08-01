﻿using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Domain.Models.Administracao;
using MediatR;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Paciente;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Medico;
using HealthMed.Domain.Models.Medico;
using HealthMed.Domain.Models.Paciente;

namespace HealthMed.Domain.Commands.Paciente
{
    public class AgendaPacienteCommandHandler : CommandHandler, IRequestHandler<AgendaPacienteCreateCommand>, IRequestHandler<AgendaPacienteDeleteCommand>
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
                log = new LogHistorico(request.IdPaciente, request.IdAgendaMedica, EnumTipoLog.CREATE, "AgendaPaciente", $"Agenda Paciente created: {request.IdAgendaMedica}");
            }
            else
            {
                log = log.SaveLogHistorico(EnumTipoLog.CREATE, "Agenda Paciente", "Error", notificationsString);
            }

            if (_notifications.HasNotifications()) await Commit(true);
            if (!_notifications.HasNotifications()) await Commit();

            return Unit.Value;
        }

        public async Task<Unit> Handle(AgendaPacienteDeleteCommand request, CancellationToken cancellationToken)
        {
            LogHistorico log = new LogHistorico();

            if (!request.IsValid())
                NotifyValidationErrors(request);
            else
            {
                AgendaPaciente? agendaPaciente = await _repository.GetById(request.IdAgendaMedica);
                if (agendaPaciente != null)
                {
                    agendaPaciente.AgendaMedica.setAgendado(false);
                    _repositoryAM.Update(agendaPaciente.AgendaMedica);
                    _repository.Remove(agendaPaciente);
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
                log = new LogHistorico(request.IdPaciente, request.IdAgendaMedica, EnumTipoLog.DELETE, "AgendaPaciente", $"Agenda Paciente deleted: {request.IdAgendaMedica}");
            }
            else
            {
                log = log.SaveLogHistorico(EnumTipoLog.DELETE, "AgendaPaciente", "Error", notificationsString);
            }

            if (_notifications.HasNotifications()) await Commit(true);
            if (!_notifications.HasNotifications()) await Commit();

            return Unit.Value;
        }
    }
}