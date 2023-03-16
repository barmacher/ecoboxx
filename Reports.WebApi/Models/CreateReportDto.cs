using AutoMapper;
using ReportsApplication.Common.Mapping;
using ReportsApplication.Reports.Commands.CreateReport;

namespace Reports.WebApi.Models
{
    public class CreateReportDto : IMapWith<CreateReportCommand>
    {
        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<CreateReportDto, CreateReportCommand>()
                .ForMember(reportCommand => reportCommand.Title,
                opt => opt.MapFrom(reportDto => reportDto.Title))
                .ForMember(reportCommand => reportCommand.Details,
                opt => opt.MapFrom(reportDto => reportDto.Details));
        }     
    }
}
