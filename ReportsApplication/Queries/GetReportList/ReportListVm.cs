using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportsApplication.Queries.GetReportList
{
    public class ReportListVm : IRequest<ReportListVm>
    {
        public IList<ReportLookupDto> Reports { get; set; }

    }
}
