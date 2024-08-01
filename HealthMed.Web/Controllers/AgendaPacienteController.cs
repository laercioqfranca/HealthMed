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

namespace HealthMed.Web.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class AgendaPacienteController : ApiController
    {
        private readonly IAgendaPacienteAppService _appService;

        public AgendaPacienteController(IAgendaPacienteAppService appService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _appService = appService;
        }

        //[HttpGet]
        //[Route("GetByFilter")]
        //public async Task<IActionResult> GetByFilter(DateTime? data, Guid? idHorario, Guid? idMedico, Guid? idPaciente)
        //{
        //    try
        //    {
        //        var result = await _appService.GetByFilter(data, idHorario, idMedico, idPaciente);
        //        return Response(result);
        //    }
        //    catch (Exception ex)
        //    {
        //        return HandleException(ex);
        //    }

        //}


        #region POST

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] AgendaPacienteDTO AgendaPacienteDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(AgendaPacienteDTO);
                }

                await _appService.Create(AgendaPacienteDTO);

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
