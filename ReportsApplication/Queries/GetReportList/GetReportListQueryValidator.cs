using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsApplication.Queries.GetReportList
{
    internal class GetReportListQueryValidator : AbstractValidator<GetReportListQuery>
    {
        public GetReportListQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(Guid.Empty);
        }
    }
}
