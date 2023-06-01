using ApplicationsApp.Common.Exceptions;
using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportDetails;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace Ecobox.Applications.Queries.GetClientsApplications
{
    public class GetClientsApplicationsQueryHandler
    : IRequestHandler<GetClientsApplicationQuery, ApplicationDetailsVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClientsApplicationsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationDetailsVm> Handle(GetClientsApplicationQuery request,
            CancellationToken cancellationToken)
        {
            var applications = await _dbContext.Applications
                .Where(a
                => a.UserId == request.UserId).ToListAsync();

            return _mapper.Map<ApplicationDetailsVm>(applications);
        }

       
    }
}
