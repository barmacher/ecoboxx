using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Commands.CompleteApplication
{
    public class CompleteApplicationCommand : IRequest<Guid>
    {
        public Guid ApplicationId { get; set; }
       
    }
}
