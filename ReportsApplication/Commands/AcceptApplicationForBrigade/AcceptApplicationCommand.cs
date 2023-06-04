using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Commands.AcceptApplication
{
    public class AcceptApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
        public int BrigadeId { get; set; }
    }
}
