using Reports.Domain;
using ReportsApplication.Common.Mapping;
using System;
using AutoMapper;
using ReportsApplication.Queries.GetReportList;
namespace ReportsApplication.Queries.GetReportList
{
    public class ReportLookupDto : IMapWith<Report>
    {
        public Guid Id { get; set; }
        public string Title { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Report, ReportLookupDto>()
                .ForMember(reportDto => reportDto.Id,
                opt => opt.MapFrom(report => report.Id))
                .ForMember(reportDto => reportDto.Title,
                opt => opt.MapFrom(report => report.Title));
        }
    }
}
