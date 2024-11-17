using TPDDSBackend.Aplication.Dtos.File;

namespace TPDDSBackend.Aplication.Services
{
    public interface IFileProcessorService
    {
        Task<bool> ProcessContributionAsync(ContributionsCsv contribution);
    }
}
