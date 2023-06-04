using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecobox.Applications.Queries.GetClientsApplications;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetBrigadesApplicationsActive
{
    public class GetActiveBrigadesApplicationsQueryHandler
    : IRequestHandler<GetActiveBrigadesApplicationsQuery, ApplicationListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActiveBrigadesApplicationsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationListVm> Handle(GetActiveBrigadesApplicationsQuery request,
            CancellationToken cancellationToken)
        {
            var applications = await _dbContext.Applications
                 .Where(a => a.BrigadeId == request.BrigadeId && a.IsActive)
                .ProjectTo<ApplicationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return new ApplicationListVm { Applications = applications };
        }


    }
}
