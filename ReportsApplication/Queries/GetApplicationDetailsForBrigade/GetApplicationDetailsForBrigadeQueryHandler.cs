using Applications.Domain;
using ApplicationsApp.Common.Exceptions;
using ApplicationsApp.Interfaces;
using AutoMapper;
using Ecobox.Applications.Queries.GetApplicationDetailsForBrigade;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace ApplicationsApp.Queries.GetReportDetails
{
    public class GetApplicationDetailsForBrigadeQueryHandler
        : IRequestHandler<GetApplicationDetailsForBrigadeQuery, ApplicationDetailsVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetApplicationDetailsForBrigadeQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ApplicationDetailsVm> Handle(GetApplicationDetailsForBrigadeQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Applications
                .FirstOrDefaultAsync(Applications
                => Applications.Id == request.Id, cancellationToken);

         
            if (entity == null || entity.BrigadeId != request.BrigadeId)
            {
                throw new NotFoundException(nameof(Application), request.Id);
            }
            return _mapper.Map<ApplicationDetailsVm>(entity);
        }
    }
}
