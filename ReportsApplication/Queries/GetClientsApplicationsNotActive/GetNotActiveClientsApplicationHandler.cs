using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using Ecobox.Applications.Queries.GetClientsApplications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetClientsApplicationsNotActive
{
    internal class GetNotActiveClientsApplicationHandler
    {
        public class GetNotActiveClientsApplicationsHandler
            : IRequestHandler<GetNotActiveClientsApplicationQuery, ApplicationListVm>
        {
            private readonly IApplicationsDbContext _dbContext;
            private readonly IMapper _mapper;

            public GetNotActiveClientsApplicationsHandler(IApplicationsDbContext dbContext, IMapper mapper)
            {
                _dbContext = dbContext;
                _mapper = mapper;
            }

            public async Task<ApplicationListVm> Handle(GetNotActiveClientsApplicationQuery request,
                CancellationToken cancellationToken)
            {
                var applications = await _dbContext.Applications
                    .Where(a
                    => a.UserId == request.UserId && a.IsActive == false).ToListAsync();

                return _mapper.Map<ApplicationListVm>(applications);
            }


        }
    }
}
