using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Domain.Commands.Auth;
using HealthMed.Domain.Interfaces.Infra.Data.Repositories.Auth;
using HealthMed.Domain.Models.Autenticacao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthMed.Application.AppServices.Autenticacao
{
    public class AutenticacaoAppService : IAutenticacaoAppService
    {
        private readonly IMapper _mapper;
        private readonly IMediatorHandler _bus;
        private readonly DomainNotificationHandler _notifications;
        private readonly IUsuarioRepository _repository;
        private readonly IHttpContextAccessor _httpContextAcessor;

        public AutenticacaoAppService(IMediatorHandler bus, INotificationHandler<DomainNotification> notifications, IMapper mapper, IUsuarioRepository repository, IHttpContextAccessor httpContextAccessor)
        {
            _bus = bus;
            _mapper = mapper;
            _notifications = (DomainNotificationHandler)notifications;
            _repository = repository;
            _httpContextAcessor = httpContextAccessor;
        }

        public async Task<UsuarioViewModel> Autenticar(LoginViewModel loginViewModel)
        {
            UsuarioViewModel userViewModel = null;
            var command = _mapper.Map<AutenticarCommand>(loginViewModel);
            await _bus.SendCommand(command);
            if (!_notifications.HasNotifications())
            {
                var usuario = (await _repository.GetByLogin(loginViewModel.Login)).FirstOrDefault();

                userViewModel = _mapper.Map<UsuarioViewModel>(usuario);

            }
            return userViewModel;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
