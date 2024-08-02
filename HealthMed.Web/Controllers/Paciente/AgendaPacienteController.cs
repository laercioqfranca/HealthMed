using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Application.DTO;
using Microsoft.AspNetCore.Authorization;
using HealthMed.Application.Interfaces.Paciente;

namespace HealthMed.Web.Controllers.Paciente
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


        #region POST

        [Route("Create")]
        [HttpPost]
        [Authorize]
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

        #region DELETE

        [Route("Delete/{idAgendaPaciente}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid idAgendaPaciente)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response();
                }

                await _appService.Delete(idAgendaPaciente);

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
