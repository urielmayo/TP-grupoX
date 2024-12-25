using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;
using TPDDSBackend.Infrastructure.Services;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class CreateFridgeFailureCommand : IRequest<CustomResponse<CreateFridgeFailureResponse>>
    {
        public CreateFridgeFailureRequest Request { get; set; }
        public CreateFridgeFailureCommand(CreateFridgeFailureRequest request)
        {
            Request = request;
        }
    }

    public class CreateFridgeFailureCommandHandler : IRequestHandler<CreateFridgeFailureCommand, CustomResponse<CreateFridgeFailureResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<FridgeFailure> _failureReposotory;
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        private readonly IJwtFactory _jwtFactory;
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CreateFridgeFailureCommandHandler(IMapper mapper, 
            IGenericRepository<FridgeFailure> failureReposotory,
            IGenericRepository<Fridge> fridgeRepository,
            IJwtFactory jwtFactory,
            IHttpContextAccessor httpContextAccessor)
        {
            _failureReposotory = failureReposotory;
            _mapper = mapper;
            _fridgeRepository = fridgeRepository;
            _jwtFactory = jwtFactory;
            _httpContextAccessor = httpContextAccessor;
        }

        public async Task<CustomResponse<CreateFridgeFailureResponse>> Handle(CreateFridgeFailureCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<FridgeFailure>(command.Request);
            byte[]? imageBytes = null;
            if (command.Request.Image != null && command.Request.Image.Length > 0)
            {
                using var memoryStream = new MemoryStream();
                await command.Request.Image.CopyToAsync(memoryStream);
                imageBytes = memoryStream.ToArray();
            }
            entity.Image = imageBytes;

            var fridge = await _fridgeRepository.GetById(entity.FridgeId);

            if (fridge == null)
                throw new ApiCustomException("Heladera no encontrada", HttpStatusCode.NotFound);

            fridge.Active = false;
            _fridgeRepository.Update(fridge);

            var jwt = _httpContextAccessor.HttpContext.Request.Headers.Authorization;

            (string collaboradorId, _) = _jwtFactory.GetClaims(jwt);
  
            entity.CollaboratorId = collaboradorId;
            await _failureReposotory.Insert(entity);

            var response = _mapper.Map<CreateFridgeFailureResponse>(entity);

            return new CustomResponse<CreateFridgeFailureResponse>("Se ha registado la falla de heladera", response);
        }
    }
}


