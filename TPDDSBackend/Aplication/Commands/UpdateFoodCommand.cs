using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;

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
        private readonly IManager<Food> _manager;
        private readonly IManager<Fridge> _fridgeManager;
        private readonly ApplicationDbContext _dbContext;


        public UpdateFoodCommandHandler(IMapper mapper,
            ApplicationDbContext dbContext,
            IManager<Food> foodManager,
            IManager<Fridge> fridgeManager)
        {
            _dbContext = dbContext;
            _manager = foodManager;
            _fridgeManager = fridgeManager;
            _mapper = mapper;
        }

        public async Task<CustomResponse<UpdateFoodResponse>> Handle(UpdateFoodCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Food>(command.Request);
            entity.Id = command.Id;


            //TODO: Revisar que exista el estado al que se esta updateando
            //TODO: Revisar que exista el donante al que se está haciendo referencia

            var fridgeResult = await _fridgeManager.FindByIdAsync(entity.FridgeId);

            if (fridgeResult != null)
            {
                throw new ApiCustomException("No existe la heladera a la que se hace referencia", HttpStatusCode.InternalServerError);
            }

            var result = await _manager.Save(entity, command.Id);

            if (!result)
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


