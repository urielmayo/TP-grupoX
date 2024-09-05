﻿using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Aplication.Managers;

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
        private readonly IMapper _mapper;
        private readonly FridgeManager _fridgeManager;
        public GetFridgeQueryHandler(IMapper mapper,
            FridgeManager fridgeManager)
        {
            _mapper = mapper;
            _fridgeManager = fridgeManager;
        }

        public async Task<CustomResponse<GetFridgeResponse>> Handle(GetFridgeQuery query, CancellationToken ct)
        {
            var fridge = await _fridgeManager.FindByIdAsync(query.FridgeId);

            if(fridge == null)
            {
               throw new ApiCustomException("heladera no encontrada", HttpStatusCode.NotFound);
            }

            var fridgeResponse = new GetFridgeResponse()
            {
                Id = fridge.Id,
                Name = fridge.Name,
                Address = fridge.Address,
                Longitud = fridge.Longitud,
                Latitud = fridge.Latitud,
                MaxFoodCapacity = fridge.MaxFoodCapacity
            };

            return new CustomResponse<GetFridgeResponse>("heladera encontrada", fridgeResponse);
            
        }
    }
}
