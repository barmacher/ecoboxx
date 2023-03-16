using System;
using MediatR;

namespace ReportsApplication.Reports.Commands.DeleteCommand
{
    public class DeleteReportCommand : IRequest
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
    }
}
