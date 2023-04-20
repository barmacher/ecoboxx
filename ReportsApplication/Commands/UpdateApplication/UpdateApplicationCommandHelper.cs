using System;
using System.Collections.Generic;
using System.Linq;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using ApplicationsApp.Interfaces;
using ApplicationsApp.Common.Exceptions;
using Applications.Domain;
using System.Reflection.Metadata;

namespace ApplicationsApp.Applications.Commands.UpdateReport
{
    public class UpdateApplicationCommandHelper
        : IRequestHandler<UpdateApplicationCommand>
    {
        private readonly IApplicationsDbContext _dbContext;

        public UpdateApplicationCommandHelper(IApplicationsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task Handle(UpdateApplicationCommand request, CancellationToken cancellationToken)
        {
            var entity =
                await _dbContext.Applications.FirstOrDefaultAsync(application => application.Id == request.Id, cancellationToken);
            if (entity == null || entity.UserId != request.UserId)
            {
                throw new NotFoundException(nameof(Application), request.Id);
            }

            entity.Description = request.Description;
            entity.Adress = request.Adress;
            entity.Number = request.Number;
            entity.EditDate = DateTime.Now;

            await _dbContext.SaveChangesAsync(cancellationToken);
        }

        
    }
}
