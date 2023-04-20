using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApplicationsApp.Queries.GetReportList
{
    public class ApplicationListVm : IRequest<ApplicationListVm>
    {
        public IList<ApplicationLookupDto> Reports { get; set; }

    }
}
