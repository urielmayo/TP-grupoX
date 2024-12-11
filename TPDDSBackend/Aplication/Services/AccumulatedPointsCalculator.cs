using System.Net;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Services
{
    public class AccumulatedPointsCalculator : IAccumulatedPointsCalculator
    {
        private readonly Dictionary<string, IContributionStrategy> _strategies;
        private readonly IBenefitCoefficientsRepository _coefficientRepository;
        public AccumulatedPointsCalculator(Dictionary<string, IContributionStrategy> strategies,
            IBenefitCoefficientsRepository coefficientRepository) 
        {
            _strategies = strategies;
            _coefficientRepository = coefficientRepository;
        } 
        public async Task<decimal> CalculateAccumulatedPoints(List<Contribution> contributions)
        {

            var coefficients = await _coefficientRepository.GetValidCoeficients();

            if (coefficients is null)
            {
                throw new ApiCustomException("Se necesita configurar los coeficientes de puntos primero", HttpStatusCode.UnprocessableEntity);
            }
            decimal accumulatedPoints = 0;
            
            foreach (var contribution in contributions)
            {
                if (!_strategies.TryGetValue(contribution.Discriminator, out var strategy))
                    throw new InvalidOperationException($"Strategy for type '{contribution.Discriminator}' not found.");

                accumulatedPoints += strategy.GetPoints(contribution, coefficients!);
            }
            
           return accumulatedPoints;
        }
    }
}
