using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReportsApplication.Queries.GetReportList
{
    public class GetReportListQuery : IRequest<ReportListVm>
    {
        public Guid UserId { get; set; }
    }
}
