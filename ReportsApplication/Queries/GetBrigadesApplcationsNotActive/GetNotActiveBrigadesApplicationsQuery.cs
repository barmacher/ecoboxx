using ApplicationsApp.Queries.GetReportList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetBrigadesApplicationsActive
{
    public class GetNotActiveBrigadesApplicationsQuery : IRequest<ApplicationListVm>
    {
        public int BrigadeId { get; set; }

    }
}
