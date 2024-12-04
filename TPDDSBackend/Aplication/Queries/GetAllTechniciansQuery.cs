using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetAllTechniciansQuery : IRequest<CustomResponse<GetAllTechniciansResponse>>{}

    public class GetAllTechniciansQueryHandler : IRequestHandler<GetAllTechniciansQuery, CustomResponse<GetAllTechniciansResponse>>{

        private readonly IGenericRepository<Technician> _technicianManager;
        private readonly IMapper _mapper;

        public GetAllTechniciansQueryHandler(IGenericRepository<Technician> technicianManager, IMapper mapper){
            _technicianManager = technicianManager;
            _mapper = mapper;
        }

        public async Task<CustomResponse<GetAllTechniciansResponse>> Handle(GetAllTechniciansQuery query, CancellationToken ct){
            var technicians =  _technicianManager.GetAll().ToList();
            var techniciansDto = _mapper.Map<IList<GetTechnicianResponse>>(technicians);
            return new CustomResponse<GetAllTechniciansResponse>("Tecnicos", new GetAllTechniciansResponse(techniciansDto));
        }
    }
}
