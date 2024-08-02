using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HealthMed.Application.Interfaces.Auth;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Domain.Enum;
using HealthMed.Web.Configurations;
using HealthMed.Application.Interfaces.TabeleDominio;

namespace HealthMed.Web.Controllers.TabelaDominio
{
    [Route("v1/[controller]")]
    [ApiController]
    public class EspecialidadeController : ApiController
    {
        private readonly IEspecialidadeAppService _appService;

        public EspecialidadeController(IEspecialidadeAppService appService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _appService = appService;
        }

        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAll()
        {
            try
            {
                var result = await _appService.GetAll();
                return Response(result);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }

        }

    }
}
