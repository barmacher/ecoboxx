using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsApp.Queries.GetReportList
{
    internal class GetApplicationListQueryValidator : AbstractValidator<GetApplicationListQuery>
    {
        public GetApplicationListQueryValidator() 
        {
            RuleFor(x => x.UserId).NotEqual(0);
        }
    }
}
