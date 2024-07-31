using MediatR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using HealthMed.Application.Interfaces.Administracao;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Core.Interfaces;
using HealthMed.Core.JWT;
using HealthMed.Core.Notifications;
using HealthMed.Web.Configurations;
using Newtonsoft.Json;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Security.Principal;
using System.Text;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces;

namespace HealthMed.Web.Controllers.Auth
{
    [Route("v1/authentication")]
    [ApiController]
    public class AgendaMedicaController : ApiController
    {
        private readonly IAgendaMedicaAppService _appService;

        public AgendaMedicaController(IAgendaMedicaAppService appService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _appService = appService;
        }


        #region POST

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgendaMedicaDTO agendaMedicaDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(agendaMedicaDTO);
                }

                await _appService.Create(agendaMedicaDTO);

                return Response();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return HandleException(ex);
            }
        }

        #endregion

    }
}
