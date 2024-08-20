using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Commands
{
    public class CreateFridgeCommand : IRequest<CustomResponse<CreateFridgeResponse>>
    {
        public CreateFridgeRequest Request { get; set; }
        public CreateFridgeCommand(CreateFridgeRequest request)
        {
            Request = request;
        }
    }

    public class CreateFridgeCommandHandler : IRequestHandler<CreateFridgeCommand, CustomResponse<CreateFridgeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly FridgeManager _manager;

        public CreateFridgeCommandHandler(IMapper mapper)
        {
            _manager = new FridgeManager();
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateFridgeResponse>> Handle(CreateFridgeCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Fridge>(command.Request);
       
            //var passwordResults = await Task.WhenAll( _userManager.PasswordValidators
            //    .Select(validator => validator.ValidateAsync(_userManager, entity, command.Request.Password)));

            //var errors = passwordResults
            //        .Where(result => !result.Succeeded)
            //        .SelectMany(result => result.Errors)
            //        .ToList();

            //if (errors.Any())
            //{
            //    throw new ValidationPasswordException("La contraseña no cumple con los requisitos de seguridad", errors);
            //}

            var result = await _manager.Save(entity);

            if (!result)
            {
                throw new ApiCustomException("Error Registrando Heladera", HttpStatusCode.InternalServerError);
            }
            
             var responseDTO= new CreateFridgeResponse()
              {
                 Id = entity.Id,
                 Address = entity.Address,
                 Name = entity.Name
              };

            return new CustomResponse<CreateFridgeResponse>("Se ha creado la heladera",responseDTO);
        }
    }
}


