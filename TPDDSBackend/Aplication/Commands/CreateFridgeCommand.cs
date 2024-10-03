using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

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
        private readonly IGenericRepository<Fridge> _repository;
        private readonly ApplicationDbContext _dbContext;


        public CreateFridgeCommandHandler(IMapper mapper, ApplicationDbContext dbContext, IGenericRepository<Fridge> repository)
        {
            _dbContext = dbContext;
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateFridgeResponse>> Handle(CreateFridgeCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Fridge>(command.Request);
       
            var result = await _repository.Insert(entity);

            if (result == null)
            {
                throw new ApiCustomException("Error Registrando Heladera", HttpStatusCode.InternalServerError);
            }
            
             var responseDTO = new CreateFridgeResponse()
              {
                 Id = entity.Id,
                 Address = entity.Address,
                 Name = entity.Name
              };

            return new CustomResponse<CreateFridgeResponse>("Se ha creado la heladera",responseDTO);
        }
    }
}


