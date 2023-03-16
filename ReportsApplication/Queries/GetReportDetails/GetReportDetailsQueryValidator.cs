using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsApplication.Queries.GetReportDetails
{
    internal class GetReportDetailsQueryValidator : AbstractValidator<GetReportDetailsQuery>

    {
        public GetReportDetailsQueryValidator() { 
            RuleFor(report => report.Id).NotEqual(Guid.Empty);
            RuleFor(report => report.UserId).NotEqual(Guid.Empty);
            
        }
    }
}
