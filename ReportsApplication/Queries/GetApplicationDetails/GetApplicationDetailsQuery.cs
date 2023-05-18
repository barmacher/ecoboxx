using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ApplicationsApp.Queries.GetReportDetails
{
    public class GetApplicationDetailsQuery : IRequest<ApplicationDetailsVm>
    {
        public int UserId { get; set; }
        public int BrigadeId { get; set; }
        public Guid Id { get; set; }
    }
}
