using Applications.Domain;
using ApplicationsApp.Common.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace ApplicationsApp.Queries.GetReportDetails
{
    public class ApplicationDetailsVm : IMapWith<Application>
    {
        public Guid Id { get; set; }

        public string Description { get; set; }

        public string Adress { get; set; }

        public int Number { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime? EditDate { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Application, ApplicationDetailsVm>()
                .ForMember(reportVm => reportVm.Description,
                opt => opt.MapFrom(report => report.Description))
                .ForMember(reportVm => reportVm.Adress,
                opt => opt.MapFrom(report => report.Adress)).
                ForMember(reportVm => reportVm.Number,
                opt => opt.MapFrom(report => report.Number))
                .ForMember(reportVm => reportVm.Id,
                opt => opt.MapFrom(report => report.Id))
                .ForMember(reportVm => reportVm.CreationDate,
                opt => opt.MapFrom(report => report.CreationDate))
                .ForMember(reportVm => reportVm.EditDate,
                opt => opt.MapFrom(report => report.EditDate)).ReverseMap();

        }
    }
}
