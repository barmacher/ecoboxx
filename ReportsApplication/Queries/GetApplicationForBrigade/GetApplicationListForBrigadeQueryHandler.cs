using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecobox.Applications.Queries.GetApplicationForBrigade;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetApplicationListForBrigadeQueryHandler
{
    internal class GetApplicationListForBrigadeQueryHandler : IRequestHandler<GetApplicationForBrigade.GetApplicationListForBrigadeQuery, ApplicationListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApplicationListForBrigadeQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationListVm> Handle(GetApplicationForBrigade.GetApplicationListForBrigadeQuery request,
            CancellationToken cancellationToken)
        {
            var applicationsQuery = await _dbContext.Applications
                .Where(application => application.BrigadeId == request.BrigadeId)
                .ProjectTo<ApplicationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ApplicationListVm { Applications = applicationsQuery };
        }

      
    }
}
