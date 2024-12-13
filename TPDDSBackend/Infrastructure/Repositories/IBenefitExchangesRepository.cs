namespace TPDDSBackend.Infrastructure.Repositories
{
    public interface IBenefitExchangesRepository
    {
        Task<decimal> GetTotalAmountSpent(string collaboratorId);
    }
}
