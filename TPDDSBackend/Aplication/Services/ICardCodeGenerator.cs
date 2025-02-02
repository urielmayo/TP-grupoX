using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Services
{
    public interface ICardCodeGenerator
    {
        Task<string> GenerateUniqueCardCode();
    }
}
