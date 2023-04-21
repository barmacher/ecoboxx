using AutoMapper;
using ApplicationsApp.Common.Mapping;
using ApplicationsApp.Applications.Commands.CreateReport;

namespace Applications.WebApi.Models
{
    public class CreateApplicationDto : IMapWith<CreateApplicationCommand>
    {
        public string Description { get; set; }

        public string Adress { get; set; }

        public int Number { get; set; }
        public int UserId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateApplicationDto, CreateApplicationCommand>()
                .ForMember(applicationCommand => applicationCommand.Description,
                opt => opt.MapFrom(applicationDto => applicationDto.Description))
                .ForMember(applicationCommand => applicationCommand.Adress,
                opt => opt.MapFrom(applicationDto => applicationDto.Adress))
                .ForMember(applicationCommand => applicationCommand.Number,
                opt => opt.MapFrom(applicationDto => applicationDto.Number))
                .ForMember(applicationCommand => applicationCommand.UserId,
                opt => opt.MapFrom(applicationDto => applicationDto.UserId));
        }     
    }
}
