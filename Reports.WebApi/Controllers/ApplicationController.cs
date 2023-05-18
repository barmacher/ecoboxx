using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Applications.WebApi.Models;
using ApplicationsApp.Queries.GetReportDetails;
using ApplicationsApp.Queries.GetReportList;
using ApplicationsApp.Applications.Commands.CreateReport;
using ApplicationsApp.Applications.Commands.DeleteCommand;
using ApplicationsApp.Applications.Commands.UpdateReport;
using Microsoft.AspNetCore.Authorization;
using Azure.Core;
using Applications.Domain;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;
using Ecobox.Applications.Commands.AssignApplication;

namespace Applications.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationController : BaseController
    {
        private readonly IMapper _mapper;
        public ApplicationController(IMapper mapper) => _mapper = mapper;

        [HttpGet]
        public async Task<ActionResult<ApplicationListVm>> GetAll()
        {
            var query = new GetApplicationListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ApplicationListVm>> Get(Guid id)
        {
            var query = new GetApplicationDetailsQuery
            {
                UserId = UserId,
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        [Authorize]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateApplicationDto createApplicationDto)
        {
            var command = _mapper.Map<CreateApplicationCommand>(createApplicationDto);
            command.UserId = UserId;
            var applicationId = await Mediator.Send(command);
            return Ok(applicationId);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateApplicationDto updateApplicationDto)
        {
            var command = _mapper.Map<UpdateApplicationCommand>(updateApplicationDto);
            command.UserId = UserId;
            await Mediator.Send(command);
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteApplicationCommand
            {
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }

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
