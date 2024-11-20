using AutoMapper;
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetAllFridgesQuery : IRequest<CustomResponse<GetAllFridgesResponse>>
    {

    }

    public class GetAllFridgesQueryHandler : IRequestHandler<GetAllFridgesQuery, CustomResponse<GetAllFridgesResponse>>
    {
        private readonly IGenericRepository<Fridge> _fridgeManager;
        private readonly IMapper _mapper;
        public GetAllFridgesQueryHandler(IGenericRepository<Fridge> fridgeManager, IMapper mapper)
        {
            _fridgeManager = fridgeManager;
            _mapper = mapper;
        }

        public async Task<CustomResponse<GetAllFridgesResponse>> Handle(GetAllFridgesQuery query, CancellationToken ct)
        {
            var fridges =  _fridgeManager.GetAll().ToList();

            var fridgesDto = _mapper.Map<IList<GetFridgeResponse>>(fridges);


            return new CustomResponse<GetAllFridgesResponse>("Heladeras encontradas", new GetAllFridgesResponse(fridgesDto));       
        }
    }
}
