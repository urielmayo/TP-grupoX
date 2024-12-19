using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class CompleteTechnicianVisitCommand : IRequest<Unit>
    {
        public CompleteTechnicianVisitRequest  Request { get; set; }
        public int Id { get; set; }
        public CompleteTechnicianVisitCommand(CompleteTechnicianVisitRequest request, int id)
        {
            Request = request;
            Id = id;
        }
    }

    public class CompleteTechnicianVisitCommandHandler : IRequestHandler<CompleteTechnicianVisitCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<TechnicianVisit> _technicianVisitRepository;


        public CompleteTechnicianVisitCommandHandler(IMapper mapper,
            IGenericRepository<TechnicianVisit> technicianVisitRepository)
        {
            _technicianVisitRepository = technicianVisitRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CompleteTechnicianVisitCommand command, CancellationToken ct)
        {

            var visit = await _technicianVisitRepository.GetById(command.Id);

            if (visit == null) 
            {
                throw new ApiCustomException("visita no encontrada", HttpStatusCode.NotFound);
            }
            
            _mapper.Map(command.Request, visit);

            _technicianVisitRepository.Update(visit);          

            return Unit.Value;
        }
    }
}


