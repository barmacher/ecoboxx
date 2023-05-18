using Applications.Domain;
using ApplicationsApp.Applications.Commands.CreateReport;
using ApplicationsApp.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Commands.AssignApplication
{
    public class AssignApplicationHandler : IRequestHandler<AssignApplicationCommand, Guid>
    {
        private readonly IApplicationsDbContext _dbContext;

        public AssignApplicationHandler(IApplicationsDbContext dbContext) =>
            _dbContext = dbContext;
        
        public async Task<Guid> Handle(AssignApplicationCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var application = await _dbContext.Applications.FirstOrDefaultAsync(obj => obj.Id == request.ApplicationId);
                if (application == null)
                {
                    throw new Exception("Is not found");
                }
                application.BrigadeId = request.BrigadeId;

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
