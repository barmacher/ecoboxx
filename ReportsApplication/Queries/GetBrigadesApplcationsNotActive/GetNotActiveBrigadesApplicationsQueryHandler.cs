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
    public class GetNotActiveBrigadesApplicationsQueryHandler
    : IRequestHandler<GetNotActiveBrigadesApplicationsQuery, ApplicationListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetNotActiveBrigadesApplicationsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationListVm> Handle(GetNotActiveBrigadesApplicationsQuery request,
            CancellationToken cancellationToken)
        {
            var applications = await _dbContext.Applications
                 .Where(a => a.BrigadeId == request.BrigadeId && a.IsActive == false)
                .ProjectTo<ApplicationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return new ApplicationListVm { Applications = applications };
        }


    }
}
