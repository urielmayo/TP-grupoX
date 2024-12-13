using AutoMapper;
using MediatR;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Domain.EF.DBContexts;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

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
        private readonly IGenericRepository<FridgeFailure> _repository;



        public CreateFridgeFailureCommandHandler(IMapper mapper, IGenericRepository<FridgeFailure> repository)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateFridgeFailureResponse>> Handle(CreateFridgeFailureCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<FridgeFailure>(command.Request);

            await _repository.Insert(entity);

            var response = _mapper.Map<CreateFridgeFailureResponse>(entity);

            return new CustomResponse<CreateFridgeFailureResponse>("Se ha creado la heladera", response);
        }
    }
}


