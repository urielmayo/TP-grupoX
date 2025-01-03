using AutoMapper;
using MediatR;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class CreateTechnicianVisitCommand : IRequest<CustomResponse<CreateTechnicianVisitResponse>>
    {
        public CreateTechnicianVisitRequest Request { get; set; }
        public CreateTechnicianVisitCommand(CreateTechnicianVisitRequest request)
        {
            Request = request;
        }
    }

    public class CreateTechnicianVisitCommandHandler : IRequestHandler<CreateTechnicianVisitCommand, CustomResponse<CreateTechnicianVisitResponse>>
    { 
        private readonly IGenericRepository<TechnicianVisit> _technicianVisitRepository;
        private readonly IGenericRepository<VisitXTechnician> _visitXTechnicianRepository;
        private readonly IMapper _mapper;

        public CreateTechnicianVisitCommandHandler(
            IGenericRepository<TechnicianVisit> technicianVisitRepository,
            IGenericRepository<VisitXTechnician> visitXTechnicianRepository,
            IMapper mapper)
        {           
            _visitXTechnicianRepository = visitXTechnicianRepository;
            _technicianVisitRepository = technicianVisitRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateTechnicianVisitResponse>> Handle(CreateTechnicianVisitCommand command, CancellationToken ct)
        {
            
            var visit = _mapper.Map<TechnicianVisit>(command.Request);
            visit.Completed = false;
            await _technicianVisitRepository.Insert(visit);

            var visitXTech = new VisitXTechnician()
            {
                TechnicianId = visit.TechnicianId,
                TechnicianVisitId = visit.Id,
            };
            await _visitXTechnicianRepository.Insert(visitXTech);

            var response = _mapper.Map<CreateTechnicianVisitResponse>(visit);
            response.LinkToUpload = $"/technician/visit/{visit.UuidToComplete}";

            return new CustomResponse<CreateTechnicianVisitResponse>("Se programo una visita de tecnico", response);
        }
    }
}


