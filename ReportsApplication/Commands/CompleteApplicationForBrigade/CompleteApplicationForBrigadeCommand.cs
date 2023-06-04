using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Commands.CompleteApplication
{
    public class CompleteApplicationForBrigadeCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
       
    }
}
