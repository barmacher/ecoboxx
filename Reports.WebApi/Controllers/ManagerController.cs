using Applications.WebApi.Controllers;
using Ecobox.Applications.Commands.AssignApplication;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecobox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ManagerController : BaseController
    {
        [HttpPost("assingToBrigade")]
        [Authorize(Roles = "Manager")]
        public async Task<ActionResult<Guid>> AssignApplicationToBrigade(Guid applicationId, [FromBody] int brigadeId)
        {
            var command = new AssignApplicationCommand
            {
                ApplicationId = applicationId,
                BrigadeId = brigadeId,

            };
            await Mediator.Send(command);
            return Ok(applicationId);

        }
    }
}
