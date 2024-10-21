using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetTechnicianQuery: IRequest<CustomResponse<GetTechnicianResponse>>
    {
        public int TechnicianId { get; set; }

        public GetTechnicianQuery(int technicianId)
        {
            TechnicianId = technicianId;
        }

    }

    public class GetTechnicianQueryHandler : IRequestHandler<GetTechnicianQuery, CustomResponse<GetTechnicianResponse>>
    {
        private readonly IGenericRepository<Technician> _genericRepository;
        public GetTechnicianQueryHandler(IGenericRepository<Technician> genericRepository)
        {
            _genericRepository = genericRepository;
        }

        public async Task<CustomResponse<GetTechnicianResponse>> Handle(GetTechnicianQuery query, CancellationToken ct)
        {
            var tech = await _genericRepository.GetById(query.TechnicianId);

            if(tech == null)
            {
               throw new ApiCustomException("Técnico no encontrado", HttpStatusCode.NotFound);
            }

            var techResponse = new GetTechnicianResponse()
            {
                Id = tech.Id,
                Name = tech.Name,
                Surname = tech.Surname,
                Email = tech.Email,
                IdNumber = tech.IdNumber,
                IdDocumentType = tech.IdDocumentType,
                PhoneNumber = tech.PhoneNumber,
                WorkerIdentificationNumber = tech.WorkerIdentificationNumber
            };

            return new CustomResponse<GetTechnicianResponse>("Técnico encontrado", techResponse);
            
        }
    }
}
