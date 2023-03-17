using System;
using MediatR;

namespace ReportsApplication.Reports.Commands.DeleteCommand
{
    public class DeleteReportCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
