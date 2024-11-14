using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class DeleteTechnicianCommand : IRequest<Unit>
    {
        public int Id { get; set; }

        public DeleteTechnicianCommand(int id)
        {
            Id = id;
        }
    }
    public class DeleteTechnicianCommandHandler : IRequestHandler<DeleteTechnicianCommand, Unit>
    {
        private readonly IGenericRepository<Technician> _repository;

        public DeleteTechnicianCommandHandler(IGenericRepository<Technician> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(DeleteTechnicianCommand command, CancellationToken ct)
        {
            var tech = await _repository.GetById(command.Id);
            if (tech == null)
                throw new ApiCustomException("Técnico no encontrado", HttpStatusCode.NotFound);

            var result = await _repository.Delete(tech.Id);

            if (!result)
            {
                throw new ApiCustomException("Error eliminando el técnico", HttpStatusCode.InternalServerError);
            }
            return Unit.Value;
        }
    }
}
