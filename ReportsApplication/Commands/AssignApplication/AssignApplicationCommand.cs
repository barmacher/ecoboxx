using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Commands.AssignApplication
{
    public class AssignApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
        public int BrigadeId { get; set; }
    }
}
