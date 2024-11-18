using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Services
{
    public interface IAccumulatedPointsCalculator
    {
        decimal CalculateAccumulatedPoints(List<Contribution> contributions);
    }
}
