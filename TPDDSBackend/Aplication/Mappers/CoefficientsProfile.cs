using AutoMapper;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Aplication.Mappers
{
    public class CoefficientsProfile: Profile
    {
        public CoefficientsProfile()
        {
            CreateMap<CoefficientsRequest, BenefitCoefficients>();
            CreateMap<BenefitCoefficients, CoefficientsResponse>();
        }
    }
}
