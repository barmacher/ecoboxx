using MediatR;
using Reports.Domain;
using ReportsApplication.Common.Exceptions;
using ReportsApplication.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ReportsApplication.Reports.Commands.DeleteCommand
{
    public class DeleteReportCommandHandler
        : IRequestHandler<DeleteReportCommand>
    {
        private readonly IReportsDbContext _dbContext;

        public DeleteReportCommandHandler(IReportsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteReportCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Reports
                .FindAsync(new object[] { request.Id }, cancellationToken);

            //if (entity == null || entity.UserId != request.UserId)
            //{
            //    throw new NotFoundException(nameof(Reports), request.Id);
            //}

            _dbContext.Reports.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
