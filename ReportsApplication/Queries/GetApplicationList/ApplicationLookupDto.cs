﻿using Applications.Domain;
using ApplicationsApp.Common.Mapping;
using System;
using AutoMapper;
using ApplicationsApp.Queries.GetReportList;
using Ecobox.Domain.Enums;

namespace ApplicationsApp.Queries.GetReportList
{
    public class ApplicationLookupDto : IMapWith<Application>
    {
        public Guid Id { get; set; }
        public string Description { get; set; }

        public string Adress { get; set; }

        public int Number { get; set; }

        public bool IsActive { get; set; } = true;

        public ApplicationStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Application, ApplicationLookupDto>()
                .ForMember(applicationDto => applicationDto.Id,
                opt => opt.MapFrom(application => application.Id))
                .ForMember(applicationDto => applicationDto.Description,
                opt => opt.MapFrom(application => application.Description))
                .ForMember(applicationDto => applicationDto.Adress,
                opt => opt.MapFrom(application => application.Adress))
                .ForMember(applicationDto => applicationDto.Number,
                opt => opt.MapFrom(application => application.Number))
                .ForMember(applicationDto => applicationDto.Status,
                opt => opt.MapFrom(application => application.Status)).ReverseMap();
        }
    }
}
