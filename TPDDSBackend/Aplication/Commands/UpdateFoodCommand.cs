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
        private readonly FoodManager _manager;
        private readonly ApplicationDbContext _dbContext;


        public UpdateFoodCommandHandler(IMapper mapper, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _manager = new FoodManager(_dbContext);
            _mapper = mapper;
        }

        public async Task<CustomResponse<UpdateFoodResponse>> Handle(UpdateFoodCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Food>(command.Request);
            entity.Id = command.Id;
            

            //TODO: Revisar que exista el estado al que se esta updateando
            //TODO: Revisar que exista la heladera a la que se está haciendo referencia
            //TODO: Revisar que exista el donante al que se está haciendo referencia

            var result = await _manager.Save(entity, command.Id);

            if (!result)
            {
                throw new ApiCustomException("Error Actualizando Vianda", HttpStatusCode.InternalServerError);
            }
            
             var responseDTO= new UpdateFoodResponse()
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


