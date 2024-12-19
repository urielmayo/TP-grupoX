using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class UpdateFridgeCommand : IRequest<CustomResponse<UpdateFridgeResponse>>
    {
        public UpdateFridgeRequest Request { get; set; }
        public int Id { get; set; }
        public UpdateFridgeCommand(UpdateFridgeRequest request, int id)
        {
            Request = request;
            Id = id;
        }
    }

    public class UpdateFridgeCommandHandler : IRequestHandler<UpdateFridgeCommand, CustomResponse<UpdateFridgeResponse>>
    {
        private readonly IMapper _mapper;
        private readonly IGenericRepository<Fridge> _fridgeRepository;
        private readonly ApplicationDbContext _dbContext;


        public UpdateFridgeCommandHandler(IMapper mapper, ApplicationDbContext dbContext, IGenericRepository<Fridge> fridgeRepository)
        {
            _dbContext = dbContext;
            _fridgeRepository = fridgeRepository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<UpdateFridgeResponse>> Handle(UpdateFridgeCommand command, CancellationToken ct)
        {
            var entity = await _fridgeRepository.GetById(command.Id);
            
            if(entity is null)
            {
                throw new ApiCustomException("No se encontro la heladera", HttpStatusCode.NotFound);
            }

            if (command?.Request?.Name is not null)
                entity.Name = command.Request.Name;


            if (command?.Request?.Address is not null)
                entity.Address = command.Request.Address;

            if (command?.Request?.Active is not null)
                entity.Active = (bool)command.Request.Active;

            if (command?.Request?.Longitud is not null)
                entity.Longitud = (decimal)command.Request.Longitud;


            if (command?.Request?.Latitud is not null)
                entity.Latitud = (decimal)command.Request.Latitud;


            if (command?.Request?.SetUpAt is not null)
                entity.SetUpAt = (DateTime)command.Request.SetUpAt;


            if (command?.Request?.MaxFoodCapacity is not null)
                entity.MaxFoodCapacity = (int)command.Request.MaxFoodCapacity;

            try
            {
                _fridgeRepository.Update(entity);
            }
            catch (Exception ex)
            {
                throw new ApiCustomException("Error Actualizando Heladera", HttpStatusCode.InternalServerError);
            }

            var responseDTO = new UpdateFridgeResponse()
            {
                Id = entity.Id,
                Address = entity.Address,
                Name = entity.Name,
                Active = entity.Active,
                Latitud = entity.Latitud,
                Longitud = entity.Longitud,
                SetUpAt = entity.SetUpAt,
                MaxFoodCapacity = entity.MaxFoodCapacity, 
            };

            return new CustomResponse<UpdateFridgeResponse>("Se ha actualizado la heladera", responseDTO);
        }
    }
}


