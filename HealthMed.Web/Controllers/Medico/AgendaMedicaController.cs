using MediatR;
using Microsoft.AspNetCore.Mvc;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces.Medico;
using Microsoft.AspNetCore.Authorization;
using HealthMed.Application.ViewModels.Medico;

namespace HealthMed.Web.Controllers.Medico
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

        #region GET

        [HttpGet]
        [Route("GetByFilter")]
        [Authorize]
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

        [HttpGet]
        [Route("GetListByIdMedico/{idMedico}")]
        [Authorize]
        public async Task<IActionResult> GetListByIdMedico(Guid idMedico)
        {
            try
            {
                var result = await _appService.GetListByIdMedico(idMedico);
                return Response(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

        #endregion

        #region POST

        [Route("Create")]
        [HttpPost]
        [Authorize]
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
