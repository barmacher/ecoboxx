using ApplicationsApp.Queries.GetReportList;
using Ecobox.Applications.Queries.GetApplicationForBrigade;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsApp.Queries.GetApplicationListForBrigadeQueryValidator
{
    public class GetApplicationListForBrigadeQueryValidator : AbstractValidator<GetApplicationListForBrigadeQuery>
    {
        public GetApplicationListForBrigadeQueryValidator() 
        {
            RuleFor(x => x.BrigadeId).NotEqual(0);
        }
    }
}
