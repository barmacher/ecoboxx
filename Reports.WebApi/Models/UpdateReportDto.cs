using AutoMapper;
using ReportsApplication.Common.Mapping;
using ReportsApplication.Reports.Commands.UpdateReport;

namespace Reports.WebApi.Models
{
    public class UpdateReportDto : IMapWith<UpdateReportDto>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }
        public string Details { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<UpdateReportDto, UpdateReportCommand>()
                .ForMember(reportCommand => reportCommand.Id,
                opt => opt.MapFrom(reportDto => reportDto.Id))
                .ForMember(reportCommand => reportCommand.Title,
                opt => opt.MapFrom(reportDto => reportDto.Title))
                .ForMember(reportCommand => reportCommand.Details,
                opt => opt.MapFrom(reportDto => reportDto.Details));
        }

    }
}
