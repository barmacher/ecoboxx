using Applications.Domain;
using ApplicationsApp.Common.Mapping;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetAllClients
{
    public class ClientsLookupDto : IMapWith<User>
    {
        public string UserName { get; set; }
        public int Id { get; set; }
        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, ClientsLookupDto>()
                .ForMember(userDto=> userDto.Id,
                opt => opt.MapFrom(user => user.Id))
               .ForMember(userDto => userDto.UserName,
                opt => opt.MapFrom(user => user.UserName))
                .ReverseMap();
        }
    }
}
