using Applications.Domain;
using ApplicationsApp.Common.Mapping;
using ApplicationsApp.Queries.GetReportList;
using AutoMapper;
using Ecobox.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecobox.Applications.Queries.GetAllBrigades
{
    public class BrigadesLookupDto : IMapWith<User>
    {
        public int Id { get; set; }
        public string UserName { get; set; }

        public ICollection<BrigadeMember> BrigadeMembers { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, BrigadesLookupDto>()
                .ForMember(brigadeDto => brigadeDto.Id,
                opt => opt.MapFrom(brigade => brigade.Id))
                .ForMember(brigadeDto => brigadeDto.UserName,
                opt => opt.MapFrom(brigade => brigade.UserName)).ReverseMap();
            //.ForMember(brigadeDto => brigadeDto.BrigadeMembers,
            //opt => opt.MapFrom(brigade => brigade.BrigadeMembers)).ReverseMap();

        }
    }

}
