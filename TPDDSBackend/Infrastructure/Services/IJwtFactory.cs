using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Infrastructure.Services
{
    public interface IJwtFactory
    {
        Task<string> GenerateEncodedToken(Collaborator user);

        (string Id, string UserName) GetClaims(string token);
    }
}
