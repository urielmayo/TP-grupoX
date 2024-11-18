using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Interfaces
{
    public interface IContributionStrategy
    {
        Dictionary<string, object> GetAttributes(Contribution contribution);

        decimal GetPoints(Contribution contribution);
    }
}
