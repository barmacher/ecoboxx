using ApplicationsApp.Queries.GetReportList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetClientsApplicationsNotActive
{
    public class GetNotActiveClientsApplicationQuery : IRequest<ApplicationListVm>
    {
        public int UserId { get; set; }
    }
}
