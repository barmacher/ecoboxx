using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Reports.Domain;
using ReportsApplication.Common.Exceptions;
using ReportsApplication.Interfaces;

namespace ReportsApplication.Queries.GetReportDetails
{
    public class GetReportDetailsQueryHandler
        : IRequestHandler<GetReportDetailsQuery, ReportDetailsVm>
    {
        private readonly IReportsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportDetailsQueryHandler(IReportsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ReportDetailsVm> Handle(GetReportDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reports
                .FirstOrDefaultAsync(Reports
                =>Reports.Id ==request.Id, cancellationToken);

            if(entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Report), request.Id);
            }
            return _mapper.Map<ReportDetailsVm>(entity);
            
        }
            

        
    }
}
