using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ReportsApplication.Interfaces;
using ReportsApplication.Common.Exceptions;
using Reports.Domain;
using System.Reflection.Metadata;

namespace ReportsApplication.Reports.Commands.UpdateReport
{
    public class UpdateReportCommandHelper
        : IRequestHandler<UpdateReportCommand>
    {
        private readonly IReportsDbContext _dbContext;

        public UpdateReportCommandHelper(IReportsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(UpdateReportCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Reports.FirstOrDefaultAsync(report => report.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Report), request.Id);
            }

            entity.Details = request.Details;
            entity.Title = request.Title;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        
    }
}
