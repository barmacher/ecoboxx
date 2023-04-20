using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ApplicationsApp.Queries.GetReportList
{
    public class GetApplicationListQuery : IRequest<ApplicationListVm>
    {
        public Guid UserId { get; set; }
    }
}
