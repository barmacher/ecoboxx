using ApplicationsApp.Queries.GetReportDetails;
using ApplicationsApp.Queries.GetReportList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetClientsApplications
{
    public class GetActiveClientsApplicationQuery : IRequest<ApplicationListVm>
    {
        public int UserId { get; set; }
     
    }
}
