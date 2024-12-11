using TPDDSBackend.Domain.Entities;

namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IBenefitCoefficientsRepository
    {
        Task<BenefitCoefficients?> GetValidCoeficients();
        Task<BenefitCoefficients> Insert(BenefitCoefficients coefficients);
    }
}
