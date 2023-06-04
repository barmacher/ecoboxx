using Applications.WebApi.Controllers;
using ApplicationsApp.Queries.GetReportDetails;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using Ecobox.Applications.Commands.AcceptApplication;
using Ecobox.Applications.Commands.AssignApplication;
using Ecobox.Applications.Commands.CompleteApplication;
using Ecobox.Applications.Queries.GetApplicationDetailsForBrigade;
using Ecobox.Applications.Queries.GetApplicationForBrigade;
using Ecobox.Applications.Queries.GetBrigadesApplicationsActive;
using Ecobox.Applications.Queries.GetClientsApplications;
using Ecobox.Applications.Queries.GetClientsApplicationsNotActive;
using Ecobox.Domain;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Ecobox.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrigadeController : BaseController
    {
        private readonly IMapper _mapper;
        public BrigadeController(IMapper mapper) => _mapper = mapper;

        [HttpGet("brigade/applications")]
        [Authorize(Roles = "BrigadeAccount")]

        public async Task<ActionResult<ApplicationListVm>> GetAllForBrigade()
        {
            var query = new GetApplicationListForBrigadeQuery
            {
                BrigadeId = BrigadeId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        
        [HttpPut("applications/acceptApplication")]
        [Authorize(Roles = "BrigadeAccount")]

        public async Task<ActionResult<ApplicationListVm>> AcceptApplication(Guid applicationId)
        {
            var command = new AcceptApplicationCommand
            {
                ApplicationId = applicationId,

            };
            await Mediator.Send(command);
            return Ok(applicationId);
        }
        [HttpGet("activeApplications")]
        [Authorize(Roles = "BrigadeAccount")]
        public async Task<ActionResult<ApplicationListVm>> GetAllActiveApplications()
        {
            var query = new GetActiveBrigadesApplicationsQuery
            {
                BrigadeId = BrigadeId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("notactiveApplications")]
        [Authorize(Roles = "BrigadeAccount")]
        public async Task<ActionResult<ApplicationListVm>> GetAllNotActiveApplications()
        {
            var query = new GetNotActiveBrigadesApplicationsQuery
            {
                BrigadeId = BrigadeId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpPut("applications/completeApplication")]
        [Authorize(Roles = "BrigdeAccount")]

        public async Task<ActionResult<ApplicationListVm>> CompleteApplication(Guid applicationId)
        {
            var command = new CompleteApplicationForBrigadeCommand
            {
                ApplicationId = applicationId,

            };
            await Mediator.Send(command);
            return Ok(applicationId);
        }
        [HttpGet("{id}")]
        [Authorize(Roles = "BrigadeAccount")]
        public async Task<ActionResult<ApplicationListVm>> Get(Guid id)
        {
            var query = new GetApplicationDetailsForBrigadeQuery
            {
                BrigadeId = BrigadeId,
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
    }
}
