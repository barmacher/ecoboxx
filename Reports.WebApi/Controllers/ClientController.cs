using Applications.Domain;
using Applications.WebApi.Controllers;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using Ecobox.Applications.Commands.CompleteApplication;
using Ecobox.Applications.Queries.GetClientsApplications;
using Ecobox.Applications.Queries.GetClientsApplicationsNotActive;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Ecobox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : BaseController
    {
        private readonly IMapper _mapper;
        public ClientController(IMapper mapper) => _mapper = mapper;

        [HttpGet("applications")]
        public async Task<ActionResult<ApplicationListVm>> GetAllForClient()
        {
            var query = new GetClientsApplicationQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPut("applications/completeApplication")]
        [Authorize(Roles = "Client")]

        public async Task<ActionResult<ApplicationListVm>> CompleteApplication(Guid applicationId)
        {
            var command = new CompleteApplicationForClientCommand
            {
                ApplicationId = applicationId,

            };
            await Mediator.Send(command);
            return Ok(applicationId);
        }
        [HttpGet("activeApplications")]
        public async Task<ActionResult<ApplicationListVm>> GetAllActiveApplications()
        {
            var query = new GetActiveClientsApplicationQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
       
        [HttpGet("notactiveApplications")]
        public async Task<ActionResult<ApplicationListVm>> GetAllNotActiveApplications()
        {
            var query = new GetNotActiveClientsApplicationQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
