using ApplicationsApp.Queries.GetReportList;
using Ecobox.Applications.Queries.GetAllClients;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetAllBrigades
{
    public class BrigadesListVm : IRequest<BrigadesListVm>
    {
        public IList<BrigadesLookupDto> Brigades { get; set; }
    }
}
