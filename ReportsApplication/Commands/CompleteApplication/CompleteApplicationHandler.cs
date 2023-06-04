using ApplicationsApp.Interfaces;
using Ecobox.Applications.Commands.AcceptApplication;
using Ecobox.Domain.Enums;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Commands.CompleteApplication
{
    internal class CompleteApplicationHandler : IRequestHandler<CompleteApplicationCommand, Guid>
    {
        private readonly IApplicationsDbContext _dbContext;

        public CompleteApplicationHandler(IApplicationsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(CompleteApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var application = await _dbContext.Applications.FirstOrDefaultAsync(obj => obj.Id == request.ApplicationId);
                if (application == null)
                {
                    throw new Exception("Is not found");
                }
                application.Status = ApplicationStatus.Completed;
                application.IsActive = false;

                _dbContext.Applications.Update(application);
                await _dbContext.SaveChangesAsync(cancellationToken);


                return application.Id;
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
        }
    }
}