﻿using MediatR;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Domain.Enum;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Interfaces.Infra.Data;
using HealthMed.Domain.Models.Administracao;
using HealthMed.Domain.Models.Autenticacao;
using HealthMed.Domain.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;
using RabbitMQ.Client;
using System.Text.Json;

namespace HealthMed.Domain.Commands.Auth
{
    public class AutenticacaoCommandHandler : CommandHandler, IRequestHandler<AutenticarCommand>
    {
        private readonly IMediatorHandler _bus;
        private readonly IUsuarioRepository _repository;
        private readonly DomainNotificationHandler _notifications;

        public AutenticacaoCommandHandler(IUsuarioRepository repository, IUnitOfWork uow, IMediatorHandler bus, INotificationHandler<DomainNotification> notifications
        ) : base(uow, bus, notifications)
        {
            _repository = repository;
            _bus = bus;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public async Task<Unit> Handle(AutenticarCommand request, CancellationToken cancellationToken)
        {
            LogHistorico log = new LogHistorico();

            if (!request.IsValid()) NotifyValidationErrors(request);
            else
            {
                var usersByLogin = await _repository.GetByLogin(request.Login);
                Usuario userQuery = usersByLogin.FirstOrDefault();

                if (!usersByLogin.Any())
                    await _bus.RaiseEvent(new DomainNotification(request.MessageType, $"Acesso Negado")); //O nome de usuário informado é inválido
                else if (usersByLogin.Count() > 1)
                    await _bus.RaiseEvent(new DomainNotification(request.MessageType, $"Acesso Negado")); //Existe mais de um usuário com o mesmo login: { request.Login.ToLower() }  
                else
                {

                    string requestSenha = GetHash(userQuery.Salt, request.Senha);

                    if (requestSenha != userQuery.Senha)
                    {
                        await _bus.RaiseEvent(new DomainNotification(request.MessageType, $"Usuário ou senha incorretos"));
                    }

                }

                //Log Histórico
                LogHistorico logHistorico = new LogHistorico();
                var notificationsString = _notifications.HasNotifications() ? string.Join(";", _notifications.GetNotifications().Select(x => x.Value)) : null;

                if (notificationsString == null)
                {
                    log = log.SaveLogHistorico(userQuery == null ? new Guid() : userQuery.Id, userQuery == null ? new Guid() : userQuery.Id, EnumTipoLog.LOGIN, "Usuario",
                     $"{userQuery.Nome} Logou com Sucesso!", notificationsString != null ? $"{request.UsuarioRequerenteId}: {notificationsString}" : notificationsString);
                }
                else
                {
                    log = log.SaveLogHistorico(new Guid(), new Guid(), EnumTipoLog.LOGIN, "Usuario",
                     "Erro", notificationsString != null ? $"{request.Login}: {notificationsString}" : notificationsString);
                }

                //var factory = new ConnectionFactory() { HostName = "localhost", UserName = "guest", Password = "guest" };
                //using var connection = factory.CreateConnection();
                //using (var channel = connection.CreateModel())
                //{
                //    channel.QueueDeclare(
                //        queue: "log",
                //        durable: false,
                //        exclusive: false,
                //        autoDelete: false,
                //        arguments: null);

                //    string message = JsonSerializer.Serialize(log);
                //    var body = Encoding.UTF8.GetBytes(message);

                //    channel.BasicPublish(
                //        exchange: "",
                //        routingKey: "log",
                //        basicProperties: null,
                //        body: body);
                //}

            }

            return Unit.Value;

        }

        private string GetSalt()
        {
            var Number = new byte[32];
            var Generator = RandomNumberGenerator.Create();
            Generator.GetBytes(Number);
            return Convert.ToBase64String(Number);
        }

        private static string GetHash(string Salt, string Password)
        {
            var SHA = SHA256.Create();
            var PasswordBytes = Encoding.UTF8.GetBytes(Salt + Password);
            var Hash = SHA.ComputeHash(PasswordBytes);
            return Convert.ToBase64String(Hash);
        }

    }
}
