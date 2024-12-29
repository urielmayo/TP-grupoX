using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface ICommunicationMediaRepository
    {
        Task<CommunicationMedia> GetByName(CommunicationMediaName name);
    }
}
