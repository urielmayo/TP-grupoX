using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands
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
            var entity = _mapper.Map<Fridge>(command.Request);
            entity.Id = command.Id;

            try
            {
                _fridgeRepository.Update(entity);
            }
            catch(Exception ex)
            {
                throw new ApiCustomException("Error Actualizando Heladera", HttpStatusCode.InternalServerError);
            }
            
             var responseDTO= new UpdateFridgeResponse()
              {
                 Id = entity.Id,
                 Address = entity.Address,
                 Name = entity.Name
              };

            return new CustomResponse<UpdateFridgeResponse>("Se ha actualizado la heladera", responseDTO);
        }
    }
}


