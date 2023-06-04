
using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportDetails;
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
using static System.Net.Mime.MediaTypeNames;

namespace Ecobox.Applications.Queries.GetActiveClientsApplicationsQueryHandler
{
    public class GetActiveClientsApplicationsQueryHandler
    : IRequestHandler<GetActiveClientsApplicationQuery, ApplicationListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetActiveClientsApplicationsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationListVm> Handle(GetActiveClientsApplicationQuery request,
            CancellationToken cancellationToken)
        {
            var applications = await _dbContext.Applications
                 .Where(a => a.UserId == request.UserId && a.IsActive)
                .ProjectTo<ApplicationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
        

            return new ApplicationListVm { Applications = applications };
        }

       
    }
}
