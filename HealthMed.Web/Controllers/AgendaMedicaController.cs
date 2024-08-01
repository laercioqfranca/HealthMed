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
using HealthMed.Application.ViewModels;

namespace HealthMed.Web.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AgendaMedicaController : ApiController
    {
        private readonly IAgendaMedicaAppService _appService;

        public AgendaMedicaController(IAgendaMedicaAppService appService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _appService = appService;
        }

        [HttpGet]
        [Route("GetByFilter")]
        public async Task<IActionResult> GetByFilter([FromQuery] AgendaMedicaFiltroViewModel filtro)
        {
            try
            {
                var result = await _appService.GetByFilter(filtro);
                return Response(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

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
