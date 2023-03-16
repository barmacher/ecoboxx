using FluentValidation;
using ReportsApplication.Reports.Commands.CreateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsApplication.Commands.CreateReport
{
    public class CreateReportCommandValidator : AbstractValidator<CreateReportCommand>
    {
        public CreateReportCommandValidator() 
        {
            RuleFor(createReportCommand =>
            createReportCommand.Title).NotEmpty().MaximumLength(500);
            RuleFor(createReportCommand =>
            createReportCommand.UserId).NotEqual(Guid.Empty);
        }
    }
}
