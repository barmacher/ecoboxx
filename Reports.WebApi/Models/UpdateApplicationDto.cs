using AutoMapper;
using ApplicationsApp.Common.Mapping;
using ApplicationsApp.Applications.Commands.UpdateReport;

namespace Applications.WebApi.Models
{
    public class UpdateApplicationDto : IMapWith<UpdateApplicationDto>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Adress { get; set; }

        public int Number { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateApplicationDto, UpdateApplicationCommand>()
                .ForMember(applicationCommand => applicationCommand.Id,
                opt => opt.MapFrom(applicationDto => applicationDto.Id))
                .ForMember(applicationCommand => applicationCommand.Description,
                opt => opt.MapFrom(applicationDto => applicationDto.Description))
                .ForMember(applicationCommand => applicationCommand.Adress,
                opt => opt.MapFrom(applicationDto => applicationDto.Adress))
                .ForMember(applicationCommand => applicationCommand.Number,
                opt => opt.MapFrom(applicationDto => applicationDto.Number));
        }

    }
}
