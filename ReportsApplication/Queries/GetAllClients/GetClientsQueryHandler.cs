//using ApplicationsApp.Interfaces;
//using ApplicationsApp.Queries.GetReportList;
//using AutoMapper;
//using AutoMapper.QueryableExtensions;
//using MediatR;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace Ecobox.Applications.Queries.GetAllClients
//{
//    internal class GetClientsQueryHandler
//      : IRequestHandler<GetClientsListQuery, ClientsListVm>
//    {
//        private readonly IApplicationsDbContext _dbContext;
//        private readonly IMapper _mapper;

//        public GetClientsQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
//        {
//            _dbContext = dbContext;
//            _mapper = mapper;
//        }

//        public async Task<ClientsListVm> Handle(GetApplicationListQuery request,
//            CancellationToken cancellationToken)
//        {
//            var clientsQuery = await _dbContext.UserRoles
//                .Include(x => x.Role)
//                .Include(x => x.User)
//                .Where(x => x.Role.Name = "Client")
//                .Select(x => x.User).ToListAsync();



//            /*await _dbContext.User*/
//            //.ProjectTo<ClientsLookupDto>(_mapper.ConfigurationProvider)
//            //.Include(x => x.Role)
//            //.Where(x => x.Role.Name = "Manager")
//            //.ToListAsync(cancellationToken);

//            return new ClientsListVm { Clients = clientsQuery };
//        }
//    }
//}
