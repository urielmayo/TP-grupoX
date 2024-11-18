using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Services
{
    public class AccumulatedPointsCalculator : IAccumulatedPointsCalculator
    {
        private readonly Dictionary<string, IContributionStrategy> _strategies;
        public AccumulatedPointsCalculator(Dictionary<string, IContributionStrategy> strategies) 
        {
            _strategies = strategies;
        } 
        public decimal CalculateAccumulatedPoints(List<Contribution> contributions)
        {
            decimal accumulatedPoints = 0;
            foreach (var contribution in contributions)
            {
                if (!_strategies.TryGetValue(contribution.Discriminator, out var strategy))
                    throw new InvalidOperationException($"Strategy for type '{contribution.Discriminator}' not found.");

                accumulatedPoints += strategy.GetPoints(contribution);
            }
            
           return accumulatedPoints;
        }
    }
}
