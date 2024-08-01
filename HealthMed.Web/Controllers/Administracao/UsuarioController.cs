using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HealthMed.Application.Interfaces.Administracao;
using HealthMed.Application.ViewModels.Administracao;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Web.Configurations.Authorization;
using HealthMed.Web.Configurations;
using HealthMed.Application.ViewModels.Auth;
using HealthMed.Application.DTO;

namespace HealthMed.Web.Controllers.Administracao
{
    [Route("v1/[controller]")]
    [ApiController]
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioAppService _appService;

        public UsuarioController(IUsuarioAppService appService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _appService = appService;
        }

        [Route("GetAll")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response();
                }


                IEnumerable<UsuarioViewModel> response = await _appService.GetAll();

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("GetByFiltro")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetByFiltro([FromQuery] ConsultarPorFiltroViewModel consultarPorFiltroViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response();
                }

                var response = await _appService.GetByFiltro(consultarPorFiltroViewModel);

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("GetById/{id}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetById(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(id);
                }
                var response = await _appService.GetById(id);

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("GetListByIdEspecialidade/{idEspecialidade}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetListByIdEspecialidade(Guid idEspecialidade)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(idEspecialidade);
                }
                var response = await _appService.GetListByIdEspecialidade(idEspecialidade);

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("Create")]
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(usuarioDTO);
                }

                await _appService.Create(usuarioDTO);

                return Response();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.InnerException.Message);
                return HandleException(ex);
            }
        }

        [Route("Update")]
        [HttpPut]
        [Authorize]
        public async Task<IActionResult> Put([FromBody] UsuarioViewModel putViewModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(putViewModel);
                }

                await _appService.Update(putViewModel);

                return Response();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("Delete/{id}")]
        [HttpDelete]
        [Authorize]
        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(id);
                }

                await _appService.Delete(id);

                return Response();
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }
    }
}
