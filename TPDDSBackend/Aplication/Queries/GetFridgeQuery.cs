using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetFridgeQuery: IRequest<CustomResponse<GetFridgeResponse>>
    {
        public int FridgeId { get; set; }

        public GetFridgeQuery(int fridgeId)
        {
            FridgeId = fridgeId;
        }

    }

    public class GetFridgeQueryHandler : IRequestHandler<GetFridgeQuery, CustomResponse<GetFridgeResponse>>
    {
        private readonly IFridgeRepository _fridgeRepository;
        private readonly IFridgeIncidentRepository _fridgeIncidentRepository;
        private readonly IGenericRepository<FridgeFailure> _fridgeFailureRepository;
        private readonly IGenericRepository<FridgeAlert> _fridgeAlertRepository;
        public GetFridgeQueryHandler(IFridgeRepository fridgeRepository,
             IFridgeIncidentRepository fridgeIncidentRepository,
             IGenericRepository<FridgeFailure> fridgeFailureRepository,
             IGenericRepository<FridgeAlert> fridgeAlertRepository)
        {
            _fridgeRepository = fridgeRepository;
            _fridgeFailureRepository = fridgeFailureRepository;
            _fridgeAlertRepository = fridgeAlertRepository;
            _fridgeIncidentRepository = fridgeIncidentRepository;
        }

        public async Task<CustomResponse<GetFridgeResponse>> Handle(GetFridgeQuery query, CancellationToken ct)
        {
            var fridge = await _fridgeRepository.GetById(query.FridgeId);

            if(fridge == null)
            {
               throw new ApiCustomException("heladera no encontrada", HttpStatusCode.NotFound);
            }

            var incidents = await _fridgeIncidentRepository.GetAllByFridge(fridge.Id);
            var incidentsResponse = new List<GetFridgeIncidentResponse>();
            foreach( var incident in incidents)
            {
                string? description = null;
                if(incident.Discriminator == "FridgeAlert")
                {
                    var alert = await _fridgeAlertRepository.GetById(incident.Id);
                    description = alert.Type.ToString();
                }
                else
                {
                    var failure = await _fridgeFailureRepository.GetById(incident.Id);
                    description = failure.Description;
                }                   
                incidentsResponse.Add(new GetFridgeIncidentResponse()
                {
                    Id = incident.Id,
                    Date = incident.Date,
                    Type = incident.Discriminator,
                    Description = description,
                });
            }

            var fridgeResponse = new GetFridgeResponse()
            {
                Id = fridge.Id,
                Name = fridge.Name,
                Address = fridge.Address,
                Longitud = fridge.Longitud,
                Latitud = fridge.Latitud,
                MaxFoodCapacity = fridge.MaxFoodCapacity,
                FoodCapacityAvailable = await _fridgeRepository.GetTotalFoodAvailable(fridge.Id),
                LastFridgeIncidents = incidentsResponse,
                Active = fridge.Active,
                SetUpAt = fridge.SetUpAt,
                CurrentTemperature = fridge.LastTemperature
            };

            return new CustomResponse<GetFridgeResponse>("heladera encontrada", fridgeResponse);
            
        }
    }
}
