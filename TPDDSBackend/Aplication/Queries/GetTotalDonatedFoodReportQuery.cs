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
    public class GetTotalDonatedFoodReportQuery : IRequest<CustomResponse<List<CollaboratorDonationCountDto>>>
    {
        public DateTime? From {  get; set; }

        public DateTime To { get; set; } = DateTime.UtcNow;

        public GetTotalDonatedFoodReportQuery(DateTime? from, DateTime? to)
        {
            From = from;
            if(to is not null)
                To = (DateTime)to;
        }
    }

    public class GetTotalDonatedFoodReportQueryHandler : IRequestHandler<GetTotalDonatedFoodReportQuery, CustomResponse<List<CollaboratorDonationCountDto>>>
    {
        private readonly ICollaboratorRepository _collaboratorRepository;
        public GetTotalDonatedFoodReportQueryHandler(ICollaboratorRepository collaboratorRepository)
        {
           _collaboratorRepository = collaboratorRepository;
        }

        public async Task<CustomResponse<List<CollaboratorDonationCountDto>>> Handle(GetTotalDonatedFoodReportQuery query, CancellationToken ct)
        {
            if(query.From is null)
                throw new ApiCustomException("Query param from is required", HttpStatusCode.BadRequest);

            if(query.From > query.To)
                throw new ApiCustomException("parametro FROM no puede ser mayor que parametro TO", HttpStatusCode.BadRequest);

            var fromUtc = DateTime.SpecifyKind((DateTime)query.From, DateTimeKind.Utc);
            var toUtc =  DateTime.SpecifyKind(query.To, DateTimeKind.Utc);
            var response = await _collaboratorRepository.GetTotalDonatedFoodsByCollaborators(fromUtc, toUtc);

            return new CustomResponse<List<CollaboratorDonationCountDto>> ("Cantidad de viandas por colaborador", response);
        }
    }
}
