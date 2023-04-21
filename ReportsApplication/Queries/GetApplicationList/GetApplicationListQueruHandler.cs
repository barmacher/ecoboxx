using ApplicationsApp.Interfaces;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsApp.Queries.GetReportList
{
    public class GetApplicationListQueruHandler
        : IRequestHandler<GetApplicationListQuery, ApplicationListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApplicationListQueruHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationListVm> Handle(GetApplicationListQuery request,
            CancellationToken cancellationToken)
        {
            var applicationsQuery = await _dbContext.Applications
                .Where(application => application.UserId == request.UserId)
                .ProjectTo<ApplicationLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ApplicationListVm { Reports = applicationsQuery };
        }
    }

}
