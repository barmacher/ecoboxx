using ApplicationsApp.Queries.GetReportList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetApplicationForBrigade
{
    public class GetApplicationListForBrigadeQuery : IRequest<ApplicationListVm>
    {
        public int BrigadeId;
    }
}
