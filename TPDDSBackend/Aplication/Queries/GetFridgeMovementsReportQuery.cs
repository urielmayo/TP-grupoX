using AutoMapper;
using MediatR;
using System;
using System.Net;
using TPDDSBackend.Aplication.Dtos.Responses;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Infrastructure.Entities;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Queries
{
    public class GetFridgeMovementsReportQuery : IRequest<CustomResponse<List<FridgeFoodStatsDto>>>
    {
        public DateTime? From {  get; set; }

        public DateTime To { get; set; } = DateTime.UtcNow;

        public GetFridgeMovementsReportQuery(DateTime? from, DateTime? to)
        {
            From = from;
            if(to is not null)
                To = (DateTime)to;
        }
    }

    public class GetFridgeMovementsReportQueryHandler : IRequestHandler<GetFridgeMovementsReportQuery, CustomResponse<List<FridgeFoodStatsDto>>>
    {
        private readonly IContributionRepository _contributionRepository;
        public GetFridgeMovementsReportQueryHandler(IContributionRepository contributionRepository)
        {
           _contributionRepository = contributionRepository;
        }

        public async Task<CustomResponse<List<FridgeFoodStatsDto>>> Handle(GetFridgeMovementsReportQuery query, CancellationToken ct)
        {
            if(query.From is null)
                throw new ApiCustomException("Query param from is required", HttpStatusCode.BadRequest);

            if(query.From > query.To)
                throw new ApiCustomException("parametro FROM no puede ser mayor que parametro TO", HttpStatusCode.BadRequest);

            var fromUtc = DateTime.SpecifyKind((DateTime)query.From, DateTimeKind.Utc);
            var toUtc =  DateTime.SpecifyKind(query.To, DateTimeKind.Utc);
            var response = await _contributionRepository.GetTotalFoodsInOutByFridge(fromUtc, toUtc);

            return new CustomResponse<List<FridgeFoodStatsDto>> ("Cantidad de viandas retiradas/colocadas por heladera", response);
        }
    }
}
