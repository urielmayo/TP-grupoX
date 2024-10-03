using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
{
    public class UpdateFoodCommand : IRequest<CustomResponse<UpdateFoodResponse>>
    {
        public UpdateFoodRequest Request { get; set; }
        public int Id { get; set; }
        public UpdateFoodCommand(UpdateFoodRequest request, int id)
        {
            Request = request;
            Id = id;
        }
    }

    public class UpdateFoodCommandHandler : IRequestHandler<UpdateFoodCommand, CustomResponse<UpdateFoodResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Food> _foodRepository;
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        private readonly IGenericRepository<FoodState> _foodStateRepository;
        private readonly UserManager<Collaborator> _userManager;


        public UpdateFoodCommandHandler(IMapper mapper,
            IGenericRepository<Food> foodRepository,
            IGenericRepository<Fridge> fridgeRepository,
            IGenericRepository<FoodState> foodStateRepository,
            UserManager<Collaborator> userManager)
        {
            _foodRepository = foodRepository;
            _fridgeRepository = fridgeRepository;
            _mapper = mapper;
            _foodStateRepository = foodStateRepository;
            _userManager = userManager;
        }

        public async Task<CustomResponse<UpdateFoodResponse>> Handle(UpdateFoodCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Food>(command.Request);
            entity.Id = command.Id;

            var fridgeResult = await _fridgeRepository.GetById(entity.FridgeId);
            if (fridgeResult == null)
                throw new ApiCustomException("No existe la heladera a la que se hace referencia", HttpStatusCode.NotFound);

            var user = await _userManager.FindByIdAsync(entity.DoneeId.ToString());
            if (user == null)
                throw new ApiCustomException("No existe el donante al que se hace referencia", HttpStatusCode.NotFound);

            var stateResult = await _foodStateRepository.GetById(entity.StateId);
            if (stateResult == null)
                throw new ApiCustomException("No existe el estado al que se hace referencia", HttpStatusCode.NotFound);


            try
            {
                _foodRepository.Update(entity);
            }
            catch(Exception ex)
            {
                throw new ApiCustomException("Error Actualizando Vianda", HttpStatusCode.InternalServerError);
            }

            var responseDTO = new UpdateFoodResponse()
            {
                Id = entity.Id,
                Description = entity.Description,
                Calories = entity.Calories,
                Weight = entity.Weight
            };

            return new CustomResponse<UpdateFoodResponse>("Se ha actualizado la vianda", responseDTO);
        }
    }
}


