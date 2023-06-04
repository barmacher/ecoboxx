using Applications.Domain;
using ApplicationsApp.Common.Exceptions;
using ApplicationsApp.Interfaces;
using AutoMapper;
using Ecobox.Applications.Queries.GetApplicationDetailsForBrigade;
using Ecobox.Applications.Queries.GetApplicationDetailsForClientQuery;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsApp.Queries.GetReportDetails
{
    public class GetApplicationDetailsForClientQueryHandler
        : IRequestHandler<GetApplicationDetailsForClientQuery, ApplicationDetailsVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApplicationDetailsForClientQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationDetailsVm> Handle(GetApplicationDetailsForClientQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Applications
                .FirstOrDefaultAsync(Applications
                => Applications.Id == request.Id, cancellationToken);


            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Application), request.Id);
            }
            return _mapper.Map<ApplicationDetailsVm>(entity);
        }
    }
}
