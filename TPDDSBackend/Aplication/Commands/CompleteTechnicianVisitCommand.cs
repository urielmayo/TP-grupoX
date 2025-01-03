using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class CompleteTechnicianVisitCommand : IRequest<Unit>
    {
        public CompleteTechnicianVisitRequest  Request { get; set; }
        public Guid Uuid { get; set; }
        public CompleteTechnicianVisitCommand(CompleteTechnicianVisitRequest request, Guid uuid)
        {
            Request = request;
            Uuid = uuid;
        }
    }

    public class CompleteTechnicianVisitCommandHandler : IRequestHandler<CompleteTechnicianVisitCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly ITechnicianVisitRepository _technicianVisitRepository;
        private readonly IGenericRepository<Fridge> _fridgeRepository;


        public CompleteTechnicianVisitCommandHandler(IMapper mapper,
            ITechnicianVisitRepository technicianVisitRepository,
            IGenericRepository<Fridge> fridgeRepository)
        {
            _technicianVisitRepository = technicianVisitRepository;
            _mapper = mapper;
            _fridgeRepository = fridgeRepository;
        }

        public async Task<Unit> Handle(CompleteTechnicianVisitCommand command, CancellationToken ct)
        {

            var visit = await _technicianVisitRepository.GetByUuid(command.Uuid);

            if (visit == null)  
            {
                throw new ApiCustomException("visita no encontrada", HttpStatusCode.NotFound);
            }
            if (visit.Completed)
            {
                throw new ApiCustomException("Ya fue completada esa visita", HttpStatusCode.UnprocessableEntity);
            }

            byte[]? fotoBytes = null;
            if (command.Request.Image != null && command.Request.Image.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await command.Request.Image.CopyToAsync(memoryStream);
                fotoBytes = memoryStream.ToArray();
            }
            _mapper.Map(command.Request, visit);
            visit.Image = fotoBytes;
            visit.Completed = true;

            _technicianVisitRepository.Update(visit);

            if (visit.FridgeRepaired)
            {
                var fridge = await _fridgeRepository.GetById(visit.FridgeId);
                fridge!.Active = true;
                _fridgeRepository.Update(fridge);
            }

            return Unit.Value;
        }
    }
}


