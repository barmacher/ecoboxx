using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using ReportsApplication.Interfaces;
using System;
using Microsoft.EntityFrameworkCore;

namespace ReportsApplication.Queries.GetReportList
{
    public class GetReportListQueruHandler
        : IRequestHandler<GetReportListQuery, ReportListVm>
    {
        private readonly IReportsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetReportListQueruHandler(IReportsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ReportListVm> Handle(GetReportListQuery request,
            CancellationToken cancellationToken)
        {
            var reportsQuery = await _dbContext.Reports
                .Where(report => report.UserId == request.UserId)
                .ProjectTo<ReportLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ReportListVm { Reports= reportsQuery };  
        } 
    }

}
