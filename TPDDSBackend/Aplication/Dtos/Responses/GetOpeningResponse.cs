using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Aplication.Dtos.Responses
{
    public class GetOpeningResponse
    {
        public int Id { get; set; }

        public string CardCode { get; set; }

        public string OpeningFor { get; set; }
    }
}
