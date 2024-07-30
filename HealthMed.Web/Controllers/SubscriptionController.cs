using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using HealthMed.Core.Interfaces;
using HealthMed.Core.Notifications;
using HealthMed.Application.DTO;
using HealthMed.Application.Interfaces;

namespace HealthMed.Web.Controllers
{
    [Route("v1/[controller]")]
    [ApiController]
    public class SubscriptionController : ApiController
    {
        private readonly ISubscriptionAppService _appService;

        public SubscriptionController(ISubscriptionAppService appService, INotificationHandler<DomainNotification> notifications, IMediatorHandler mediator)
            : base(notifications, mediator)
        {
            _appService = appService;
        }

        [Route("GetAllById/{id}")]
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetAllById(Guid id)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    NotifyModelStateErrors();
                    return Response(id);
                }
                var response = await _appService.GetAllById(id);

                return Response(response);
            }
            catch (Exception ex)
            {
                return HandleException(ex);
            }
        }

        [Route("CreateSubscription")]
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateSubscription2([FromBody] SubscriptionDTO inscricaoDTO)
        {
            try
            {
                await _appService.Create(inscricaoDTO);
                return Response();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return BadRequest(ex.Message);
            }
        }

        [Route("DeleteSubscription/{id}")]
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
