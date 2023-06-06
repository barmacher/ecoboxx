using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetAllClients
{
    public class GetClientsQueryHandler
      : IRequestHandler<GetClientsListQuery, ClientsListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetClientsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<ClientsListVm> Handle(GetClientsListQuery request,
            CancellationToken cancellationToken)
        {
            
            var d = _dbContext.UserRoles.Where(ur => ur.RoleId == 3).Select(ur => ur.UserId).ToList();
            var a = await _dbContext.Users.Where(u => d.Contains(u.Id))
                .ProjectTo<ClientsLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            //var clientsQuery = await _dbContext.UserRoles
            //    .Include(x => x.Role)
            //    .Include(x => x.User)
            //    .Where(x => x.Role.Id == 3)
            //    .Select(x => x.User)
            //    .ProjectTo<ClientsLookupDto>(_mapper.ConfigurationProvider)
            //    .ToListAsync(cancellationToken);




            /*await _dbContext.User*/
            //.ProjectTo<ClientsLookupDto>(_mapper.ConfigurationProvider)
            //.Include(x => x.Role)
            //.Where(x => x.Role.Name = "Manager")
            //.ToListAsync(cancellationToken);

            return new ClientsListVm { Clients = a
            };
}
    }
}
