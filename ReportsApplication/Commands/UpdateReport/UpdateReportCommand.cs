using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace ReportsApplication.Reports.Commands.UpdateReport
{
    public class UpdateReportCommand : IRequest
    {
        public Guid UserId { get; set; }    

        public Guid Id { get; set; }

        public string Title { get; set; }   

        public string Details { get; set; }
    }
}
