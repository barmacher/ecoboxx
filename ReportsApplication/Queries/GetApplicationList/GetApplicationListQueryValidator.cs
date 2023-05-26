using Ecobox.Applications.Queries.GetApplicationForBrigade;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsApp.Queries.GetReportList
{
    internal class GetApplicationListForBrigadeQueryValidator : AbstractValidator<GetApplicationListForBrigadeQuery>
    {
        public GetApplicationListForBrigadeQueryValidator() 
        {
            RuleFor(x => x.BrigadeId).NotEqual(0);
        }
    }
}
