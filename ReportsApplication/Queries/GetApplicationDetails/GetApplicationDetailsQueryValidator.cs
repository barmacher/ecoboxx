using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsApp.Queries.GetReportDetails
{
    internal class GetApplicationDetailsQueryValidator : AbstractValidator<GetApplicationDetailsQuery>

    {
        public GetApplicationDetailsQueryValidator() { 
            RuleFor(application => application.Id).NotEqual(Guid.Empty);
            RuleFor(application => application.UserId).NotEqual(Guid.Empty);
            
        }
    }
}
