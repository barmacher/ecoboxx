using ApplicationsApp.Interfaces;
using Ecobox.Applications.Commands.AssignApplication;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Ecobox.Domain.Enums;
using MediatR;

namespace Ecobox.Applications.Commands.AcceptApplication
{
    internal class AcceptApplicationHandler : IRequestHandler<AcceptApplicationCommand, Guid>
    {
        private readonly IApplicationsDbContext _dbContext;

        public AcceptApplicationHandler(IApplicationsDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Guid> Handle(AcceptApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var application = await _dbContext.Applications.FirstOrDefaultAsync(obj => obj.Id == request.ApplicationId);
                if (application == null)
                {
                    throw new Exception("Is not found");
                }
                application.Status = ApplicationStatus.Running;

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
