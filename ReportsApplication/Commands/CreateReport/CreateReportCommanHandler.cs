using MediatR;
using Reports.Domain;
using ReportsApplication.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ReportsApplication.Reports.Commands.CreateReport
{
    internal class CreateReportCommanHandler : IRequestHandler<CreateReportCommand, Guid>
    {
        private readonly IReportsDbContext _dbContext;

        public CreateReportCommanHandler(IReportsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {
            var report = new Report
            {
                UserId = request.UserId,
                Title = request.Title,
                Details = request.Details,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null

            };

            await _dbContext.Reports.AddAsync(report, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return report.Id;
        }
    }
}
