using FluentValidation;
using ReportsApplication.Reports.Commands.DeleteCommand;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsApplication.Commands.DeleteCommand
{
    public class DeleteReportCommandValidator : AbstractValidator<DeleteReportCommand>
    {
        public DeleteReportCommandValidator()
        {
            RuleFor(deleteReportCommand => deleteReportCommand.Id).NotEqual(Guid.Empty);
            RuleFor(deleteReportCommand => deleteReportCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
