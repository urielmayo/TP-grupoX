﻿using AutoMapper;
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
    public class CreateFoodCommand : IRequest<CustomResponse<CreateFoodResponse>>
    {
        public CreateFoodRequest Request { get; set; }
        public CreateFoodCommand(CreateFoodRequest request)
        {
            Request = request;
        }
    }

    public class CreateFoodCommandHandler : IRequestHandler<CreateFoodCommand, CustomResponse<CreateFoodResponse>>
    {
        private readonly IMapper _mapper;
        private readonly FoodManager _manager;
        private readonly ApplicationDbContext _dbContext;


        public CreateFoodCommandHandler(IMapper mapper, ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
            _manager = new FoodManager(_dbContext);
            _mapper = mapper;
        }

        public async Task<CustomResponse<CreateFoodResponse>> Handle(CreateFoodCommand command, CancellationToken ct)
        {
            var entity = _mapper.Map<Food>(command.Request);
       
            var result = await _manager.Save(entity);

            if (!result)
            {
                throw new ApiCustomException("Error Registrando Vianda", HttpStatusCode.InternalServerError);
            }
            
             var responseDTO= new CreateFoodResponse()
              {
                 Id = entity.Id,
                 Description = entity.Description,
                 Weight = entity.Weight,
                 Calories = entity.Calories
              };

            return new CustomResponse<CreateFoodResponse>("Se ha creado la vianda", responseDTO);
        }
    }
}


