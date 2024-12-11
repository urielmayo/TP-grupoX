using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Aplication.Services
{
    public interface IAccumulatedPointsCalculator
    {
        Task<decimal> CalculateAccumulatedPoints(List<Contribution> contributions);
    }
}
