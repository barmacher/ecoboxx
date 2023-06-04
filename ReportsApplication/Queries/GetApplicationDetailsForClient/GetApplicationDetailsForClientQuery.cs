using ApplicationsApp.Queries.GetReportDetails;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetApplicationDetailsForClientQuery
{
    public class GetApplicationDetailsForClientQuery : IRequest<ApplicationDetailsVm>
    {
        public int UserId { get; set; }
        public int BrigadeId { get; set; }
        public Guid Id { get; set; }
    }
}
