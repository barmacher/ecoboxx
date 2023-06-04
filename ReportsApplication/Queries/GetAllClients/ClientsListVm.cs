using ApplicationsApp.Queries.GetReportList;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetAllClients
{
    public class ClientsListVm : IRequest<ClientsListVm>
    {
        public IList<ClientsLookupDto> Clients { get; set; }
    }
}
