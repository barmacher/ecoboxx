using FluentValidation;
using ReportsApplication.Reports.Commands.UpdateReport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsApplication.Commands.UpdateReport
{
    public class UpdateReportCommandValidator : AbstractValidator<UpdateReportCommand>
    {
        public UpdateReportCommandValidator() 
        {
            RuleFor(updateReportCommand => updateReportCommand.UserId).NotEqual(Guid.Empty);
            RuleFor(updateReportCommand => updateReportCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateReportCommand => updateReportCommand.Title)
                .NotEmpty().MaximumLength(500);
            
        }
    }
}
