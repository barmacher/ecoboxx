using MediatR;
using Applications.Domain;
using ApplicationsApp.Common.Exceptions;
using ApplicationsApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ApplicationsApp.Applications.Commands.DeleteCommand
{
    public class DeleteApplicationCommandHandler
        : IRequestHandler<DeleteApplicationCommand>
    {
        private readonly IApplicationsDbContext _dbContext;

        public DeleteApplicationCommandHandler(IApplicationsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task Handle(DeleteApplicationCommand request,
            CancellationToken cancellationToken)
        {
            var entity = await _dbContext.Applications
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (entity == null)
            {
                throw new NotFoundException(nameof(Applications), request.Id);
            }

            _dbContext.Applications.Remove(entity);
            await _dbContext.SaveChangesAsync(cancellationToken);

        }
    }
}
