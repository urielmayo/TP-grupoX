using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Reflection;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace TPDDSBackend.Aplication.Commands
{
    public class UpdateCollaboratorCommand : IRequest<CustomResponse<CreateCollaboratorResponse>>
    {
        public string CollaboratorId { get; set; }
        public UpdateCollaboratorRequest Request { get; set; }

        public UpdateCollaboratorCommand(string collaboratorId,UpdateCollaboratorRequest request)
        {
            CollaboratorId = collaboratorId;
            Request = request;
        }
    }
    public class UpdateCollaboratorCommandHandler : IRequestHandler<UpdateCollaboratorCommand, CustomResponse<CreateCollaboratorResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Collaborator> _userManager;
        public UpdateCollaboratorCommandHandler(IMapper mapper,
            UserManager<Collaborator> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CustomResponse<CreateCollaboratorResponse>> Handle(UpdateCollaboratorCommand command, CancellationToken ct)
        {
            var user = await _userManager.FindByIdAsync(command.CollaboratorId);

            if (user == null)
            {
                throw new ApiCustomException("Usuario no encontrado", HttpStatusCode.NotFound);
            }

            foreach (PropertyInfo property in command.Request.GetType().GetProperties())
            {
                
                PropertyInfo originalProperty = user.GetType().GetProperty(property.Name);

                if (originalProperty != null)
                {
                    object newValue = property.GetValue(command.Request);
                    originalProperty.SetValue(user, newValue);
                }
            }

            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded)
            {
                throw new ApiCustomException("Error actualizando Usuario", HttpStatusCode.InternalServerError);
            }

            var responsedTO = new CreateCollaboratorResponse()
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            };

            return new CustomResponse<CreateCollaboratorResponse>("Se ha actualizado el colaborador", responsedTO);
        }
    }
}
