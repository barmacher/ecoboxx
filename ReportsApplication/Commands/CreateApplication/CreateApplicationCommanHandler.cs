﻿using MediatR;
using Applications.Domain;
using ApplicationsApp.Interfaces;
using System.Threading;
using System.Threading.Tasks;

namespace ApplicationsApp.Applications.Commands.CreateReport
{
    internal class CreateApplicationCommanHandler : IRequestHandler<CreateApplicationCommand, Guid>
    {
        private readonly IApplicationsDbContext _dbContext;

        public CreateApplicationCommanHandler(IApplicationsDbContext dbContext) =>
            _dbContext = dbContext;
        public async Task<Guid> Handle(CreateApplicationCommand request, CancellationToken cancellationToken)
        {
            var application = new Application
            {
                UserId = request.UserId,
                Description = request.Description,
                Adress = request.Adress,
                Number = request.Number,
                Id = Guid.NewGuid(),
                CreationDate = DateTime.Now,
                EditDate = null

            };

            await _dbContext.Applications.AddAsync(application, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return application.Id;
        }
    }
}
