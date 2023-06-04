using ApplicationsApp.Common.Exceptions;
using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportDetails;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
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
    : IRequestHandler<GetClientsApplicationQuery, ApplicationListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClientsApplicationsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationListVm> Handle(GetClientsApplicationQuery request,
            CancellationToken cancellationToken)
        {

            //var applications = await _dbContext.Applications
            //    .Where(a
            //=> a.UserId == request.UserId);
            //var res = new ApplicationListVm { Applications = applications };

            //return res;
            var applicationsQuery = await _dbContext.Applications
               .Where(application => application.UserId == request.UserId)
               .ProjectTo<ApplicationLookupDto>(_mapper.ConfigurationProvider)
               .ToListAsync(cancellationToken);

            return new ApplicationListVm { Applications = applicationsQuery };






        }

    }

}
