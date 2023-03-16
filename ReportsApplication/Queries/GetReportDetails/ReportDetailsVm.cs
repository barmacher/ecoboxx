using Reports.Domain;
using ReportsApplication.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ReportsApplication.Queries.GetReportDetails
{
    public class ReportDetailsVm : IMapWith<Report>
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Details { get; set; }

        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Report, ReportDetailsVm>()
                .ForMember(reportVm => reportVm.Title,
                opt => opt.MapFrom(report => report.Title))
                .ForMember(reportVm => reportVm.Details,
                opt => opt.MapFrom(report => report.Details))
                .ForMember(reportVm => reportVm.Id,
                opt => opt.MapFrom(report => report.Id))
                .ForMember(reportVm => reportVm.CreationDate,
                opt => opt.MapFrom(report => report.CreationDate))
                .ForMember(reportVm => reportVm.EditDate,
                opt => opt.MapFrom(report => report.EditDate));
        }
    }
}
