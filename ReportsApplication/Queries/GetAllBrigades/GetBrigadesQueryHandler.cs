using ApplicationsApp.Interfaces;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Ecobox.Applications.Queries.GetAllCBrigades;
using Ecobox.Applications.Queries.GetAllClients;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetAllBrigades
{
    public class GetBrigadesQueryHandler
      : IRequestHandler<GetBrigadesListQuery, BrigadesListVm>
    {
        private readonly IApplicationsDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetBrigadesQueryHandler(IApplicationsDbContext dbContext, IMapper mapper)
        {
            _dbContext = dbContext;
            _mapper = mapper;
        }

        public async Task<BrigadesListVm> Handle(GetBrigadesListQuery request,
            CancellationToken cancellationToken)
        {
            
            var d = _dbContext.UserRoles.Where(ur => ur.RoleId == 2).Select(ur => ur.UserId).ToList();
            var a = await _dbContext.Users.Where(u => d.Contains(u.Id))
                .ProjectTo<BrigadesLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new BrigadesListVm { Brigades = a };
}
    }
}
