using Applications.WebApi.Controllers;
using ApplicationsApp.Queries.GetReportList;
using Ecobox.Applications.Commands.AssignApplication;
using Ecobox.Applications.Queries.GetAllBrigades;
using Ecobox.Applications.Queries.GetAllCBrigades;
using Ecobox.Applications.Queries.GetAllClients;
using Ecobox.Applications.Queries.GetApplicationForBrigade;
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
        [HttpGet("allClients")]
        [Authorize(Roles = "Manager")]

        public async Task<ActionResult<ClientsListVm>> GetAllClients()
        {
            var query = new GetClientsListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("allBrigades")]
        [Authorize(Roles = "Manager")]

        public async Task<ActionResult<BrigadesListVm>> GetAllBrigades()
        {
            var query = new GetBrigadesListQuery
            {
                BrigadeId = BrigadeId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

    }
}
