using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ApplicationsApp.Applications.Commands.UpdateReport
{
    public class UpdateApplicationCommand : IRequest
    {
        public Guid UserId { get; set; }    

        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Adress { get; set; }

        public int Number { get; set; }
    }
}
