using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TPDDSBackend.Aplication.Commands.Collaborators
{
    public class DeleteCollaboratorCommand : IRequest<Unit>
    {
        public string CollaboratorId { get; set; }

        public DeleteCollaboratorCommand(string collaboratorId)
        {
            CollaboratorId = collaboratorId;
        }
    }
    public class DeleteCollaboratorCommandHandler : IRequestHandler<DeleteCollaboratorCommand, Unit>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Collaborator> _userManager;
        public DeleteCollaboratorCommandHandler(IMapper mapper,
            UserManager<Collaborator> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<Unit> Handle(DeleteCollaboratorCommand command, CancellationToken ct)
        {
            var user = await _userManager.FindByIdAsync(command.CollaboratorId);

            if (user == null)
            {
                throw new ApiCustomException("Usuario no encontrado", HttpStatusCode.NotFound);
            }

            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded)
            {
                throw new ApiCustomException("Error eliminando Usuario", HttpStatusCode.InternalServerError);
            }
            return Unit.Value;
        }
    }
}
