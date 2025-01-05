
using MediatR;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Infrastructure.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetFridgeFailureReportQuery : IRequest<CustomResponse<List<FridgeIncidentCountDto>>>
    {
        public DateTime? From {  get; set; }

        public DateTime To { get; set; } = DateTime.UtcNow;

        public GetFridgeFailureReportQuery(DateTime? from, DateTime? to)
        {
            From = from;
            if(to is not null)
                To = (DateTime)to;
        }
    }

    public class GetFridgeFailureReportQueryHandler : IRequestHandler<GetFridgeFailureReportQuery, CustomResponse<List<FridgeIncidentCountDto>>>
    {
        private readonly IFridgeIncidentRepository _fridgeIncidentRepository;
        public GetFridgeFailureReportQueryHandler(IFridgeIncidentRepository fridgeIncidentRepository)
        {
            _fridgeIncidentRepository = fridgeIncidentRepository;
        }

        public async Task<CustomResponse<List<FridgeIncidentCountDto>>> Handle(GetFridgeFailureReportQuery query, CancellationToken ct)
        {
            if(query.From is null)
                throw new ApiCustomException("Query param from is required", HttpStatusCode.BadRequest);

            if(query.From > query.To)
                throw new ApiCustomException("parametro FROM no puede ser mayor que parametro TO", HttpStatusCode.BadRequest);

            var fromUtc = DateTime.SpecifyKind((DateTime)query.From, DateTimeKind.Utc);
            var toUtc =  DateTime.SpecifyKind(query.To, DateTimeKind.Utc);
            var response = await _fridgeIncidentRepository.GetTotalIncidentsByFridge(fromUtc, toUtc);

            return new CustomResponse<List<FridgeIncidentCountDto>> ("Cantidad de fallas por heladera", response);
        }
    }
}
