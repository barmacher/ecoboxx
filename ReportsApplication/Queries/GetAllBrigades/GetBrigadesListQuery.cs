using ApplicationsApp.Queries.GetReportList;
using Ecobox.Applications.Queries.GetAllBrigades;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetAllCBrigades
{
    public class GetBrigadesListQuery : IRequest<BrigadesListVm>
    {
        public int BrigadeId { get; set; }

    }
}
