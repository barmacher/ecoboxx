using Applications.Domain;
using ApplicationsApp.Common.Exceptions;
using ApplicationsApp.Interfaces;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsApp.Queries.GetReportDetails
{
    public class GetApplicationDetailsQueryHandler
        : IRequestHandler<GetApplicationDetailsQuery, ApplicationDetailsVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApplicationDetailsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationDetailsVm> Handle(GetApplicationDetailsQuery request,
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
