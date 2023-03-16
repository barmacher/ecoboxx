using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Reports.WebApi.Models;
using ReportsApplication.Queries.GetReportDetails;
using ReportsApplication.Queries.GetReportList;
using ReportsApplication.Reports.Commands.CreateReport;
using ReportsApplication.Reports.Commands.DeleteCommand;
using ReportsApplication.Reports.Commands.UpdateReport;

namespace Reports.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : BaseController
    {
        private readonly IMapper _mapper;
        public ReportController(IMapper mapper) => _mapper = mapper;
        [HttpGet]
        public async Task<ActionResult<ReportListVm>> GetAll()
        {
            var query = new GetReportListQuery
            {
                UserId = UserId
            };
            var vm = await Mediator.Send(query);
            return Ok(vm);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<ReportListVm>> Get(Guid id)
        {
            var query = new GetReportDetailsQuery
            {
                UserId = UserId,
                Id = id
            };

            var vm = await Mediator.Send(query);
            return Ok(vm);
        }

        [HttpPost]
        public async Task<ActionResult<Guid>> Create([FromBody] CreateReportDto createReportDto)
        {
            var command = _mapper.Map<CreateReportCommand>(createReportDto);
            command.UserId = UserId;
            var reportId = await Mediator.Send(command);
            return Ok(reportId);

        }

        [HttpPut]
        public async Task<IActionResult> Update([FromBody] UpdateReportDto updateReportDto)
        {
            var command = _mapper.Map<UpdateReportCommand>(updateReportDto);
            command.UserId = UserId;
            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(Guid id)
        {
            var command = new DeleteReportCommand
            {
                UserId = UserId,
                Id = id
            };
            await Mediator.Send(command);
            return NoContent();
        }


    }
}
