using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Commands;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetCollaboratorQuery: IRequest<CustomResponse<GetCollaboratorResponse>>
    {
        public string CollaboratorId { get; set; }

        public GetCollaboratorQuery(string collaboratorId)
        {
            CollaboratorId = collaboratorId;
        }

    }

    public class GetCollaboratorQueryHandler : IRequestHandler<GetCollaboratorQuery, CustomResponse<GetCollaboratorResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Collaborator> _userManager;
        public GetCollaboratorQueryHandler(IMapper mapper,
            UserManager<Collaborator> userManager)
        {
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task<CustomResponse<GetCollaboratorResponse>> Handle(GetCollaboratorQuery query, CancellationToken ct)
        {
            var user = await _userManager.FindByIdAsync(query.CollaboratorId);

            if(user == null)
            {
               throw new ApiCustomException("usuario no encontrado", HttpStatusCode.NotFound);
            }
            var rol = await _userManager.GetRolesAsync(user);

            var userResponse = new GetCollaboratorResponse()
            {
                Id = user.Id,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName!,
                Rol = rol.FirstOrDefault()
            };

            return new CustomResponse<GetCollaboratorResponse>("usuario encontrado", userResponse);
            
        }
    }
}
