using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Requests;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Commands.Fridges
{
    public class SetupTemperaturesFridgeCommand : IRequest<CustomResponse<SetupTemperaturesResponse>>
    {
        public SetupTemperaturesRequest Temperatures { get; set; }
        public int FridgeModelId { get; set; }
        public SetupTemperaturesFridgeCommand(SetupTemperaturesRequest temperatures, int fridgeModelId)
        {
            Temperatures = temperatures;
            FridgeModelId = fridgeModelId;
        }
    }

    public class SetupTemperaturesFridgeCommandHandler : IRequestHandler<SetupTemperaturesFridgeCommand, CustomResponse<SetupTemperaturesResponse>>
    {
        private readonly IGenericRepository<FridgeModel> _fridgeModelRepository;
        private readonly IMapper _Mapper;


        public SetupTemperaturesFridgeCommandHandler(IGenericRepository<FridgeModel> fridgeModelRepository, IMapper mapper)
        {
            _fridgeModelRepository = fridgeModelRepository;
            _Mapper = mapper;
        }

        public async Task<CustomResponse<SetupTemperaturesResponse>> Handle(SetupTemperaturesFridgeCommand command, CancellationToken ct)
        {
            var fridgeModel = await _fridgeModelRepository.GetById(command.FridgeModelId);
      
           if(fridgeModel == null)
            {
                throw new ApiCustomException("No se ha encontrado el modelo de heladera", HttpStatusCode.NotFound);
            }

            fridgeModel.MaxTemperature = command.Temperatures.MaxTemperature;
            fridgeModel.MinTemperature = command.Temperatures.MinTemperature;
             _fridgeModelRepository.Update(fridgeModel);


            return new CustomResponse<SetupTemperaturesResponse>("Se ha confgurado correctamente las temperaturas", _Mapper.Map<SetupTemperaturesResponse>(fridgeModel));
        }
    }
}


