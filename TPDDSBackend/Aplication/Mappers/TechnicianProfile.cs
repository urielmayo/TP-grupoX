﻿using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Mappers
{
    public class TechnicianProfile : Profile
    {
        public TechnicianProfile()
        {
            CreateMap<CreateTechnicianRequest, Technician>();
            CreateMap<UpdateTechnicianRequest, Technician>();
            CreateMap<Technician, GetTechnicianResponse>()
                .ForMember(dest => dest.DocumentTypeName, opt => opt.MapFrom(src => src.DocumentType.Description))
                .ForMember(dest => dest.NeighbourhoodName, opt => opt.MapFrom(src => src.Neighborhood.Name));

            CreateMap<CreateTechnicianVisitRequest, TechnicianVisit>();
            CreateMap<TechnicianVisit, CreateTechnicianVisitResponse>();

            CreateMap<CompleteTechnicianVisitRequest, TechnicianVisit>()
                        .ForAllMembers(opts =>
                opts.Condition((src, dest, srcMember) => srcMember != null));
        }
    }
}

