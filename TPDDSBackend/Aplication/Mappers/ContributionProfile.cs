﻿using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Mappers
{
    public class ContributionProfile: Profile
    {
        public ContributionProfile()
        {
            CreateMap<OwnAFridgeContributionRequest, FridgeOwner>();

            CreateMap<FoodDeliveryContributionRequest, FoodDelivery>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => ContributionStatus.Requested));

            CreateMap<Contribution,ContributionByCollaboratorResponse>()
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Discriminator));

            CreateMap<CreateBenefitRequest, Benefit>();
        }
    }
}
