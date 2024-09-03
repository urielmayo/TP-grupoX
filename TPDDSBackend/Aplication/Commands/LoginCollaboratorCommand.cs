using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands
{
    public class LoginCollaboratorCommand: IRequest<CustomResponse<LoginCollaboratorResponse>>
    {
        public LoginCollaboratorRequest Request { get; set; }

        public LoginCollaboratorCommand(LoginCollaboratorRequest request)
        {
            Request = request;
        }
    }

    public class LoginCollaboratorCommandHandler : IRequestHandler<LoginCollaboratorCommand, CustomResponse<LoginCollaboratorResponse>>
    {
        private readonly IMapper _mapper;
        private readonly UserManager<Collaborator> _userManager;
        private readonly IJwtFactory _jwtFactory;

        public LoginCollaboratorCommandHandler(IMapper mapper,
            UserManager<Collaborator> userManager,
            IJwtFactory jwtFactory)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtFactory = jwtFactory;
        }

        public async Task<CustomResponse<LoginCollaboratorResponse>> Handle(LoginCollaboratorCommand command, CancellationToken ct)
        {
            var user = await _userManager.FindByNameAsync(command.Request.UserName);
            if (user == null)
            {
                throw new ApiCustomException("El usuario no existe", HttpStatusCode.NotFound);
            }

            var result = await _userManager.CheckPasswordAsync(user, command.Request.Password);
            if (!result)
            {
                throw new ApiCustomException("La contraseña es incorrecta", HttpStatusCode.Forbidden);
            }

            var token = await _jwtFactory.GenerateEncodedToken(user);

            var response = new LoginCollaboratorResponse()
            {
                Jwt = token,
                Id = user.Id
            };
            return new CustomResponse<LoginCollaboratorResponse>("iniciado correctamente", response);
        }
    }
}
