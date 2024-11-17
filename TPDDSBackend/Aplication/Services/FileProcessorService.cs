using Microsoft.AspNetCore.Identity;
using System.Net;
using TPDDSBackend.Aplication.Dtos.File;
using TPDDSBackend.Aplication.Exceptions;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Aplication.Services
{
    public class FileProcessorService: IFileProcessorService
    {
        private readonly UserManager<Collaborator> _userManager;
        private readonly IGenericRepository<Contribution> _contributionRepository;
        private static Dictionary<TypeContribution, string> DiscriminatorsMap = new Dictionary<TypeContribution, string>() 
        {
            {TypeContribution.DINERO, "MoneyDonation" },
            {TypeContribution.REDISTRIBUCION_VIANDAS, "FoodDelivery" },
            {TypeContribution.DONACION_VIANDAS, "FoodDonation" },
            {TypeContribution.ENTREGA_TARJETAS, "Card" }
        };
        private const string DEFAULT_CONTRIBUTION = "DEFAULT";

        public FileProcessorService(UserManager<Collaborator> userManager,
            IGenericRepository<Contribution> contributionRepository)
        {
            _userManager = userManager;
            _contributionRepository = contributionRepository;
        }
        public async Task<bool> ProcessContributionAsync(ContributionsCsv contribution)
        {
            bool isNewUser = false;
            var userExist = await _userManager.FindByEmailAsync(contribution.Mail);

            if (userExist == null)
            {
                isNewUser = true;
                var newUser = new HumanPerson
                {
                    UserName = contribution.Mail,
                    Surname = contribution.Apellido,
                    Name = contribution.Nombre,
                    Email = contribution.Mail,
                };              
                var password = $"x{_userManager.GenerateNewAuthenticatorKey()}1.";
                var result = await _userManager.CreateAsync (newUser, password);

                if (result.Succeeded)
                {
                   
                    //Enviar email avisando que se creo un nuevo usuario
                    userExist = await _userManager.FindByEmailAsync(contribution.Mail);
                }
                else
                {
                    isNewUser = false;
                }
            }

            var contributionEntity = new Contribution()
            {
                CollaboratorId = userExist.Id,
                Date = DateTime.UtcNow,
                Discriminator = DiscriminatorsMap.GetValueOrDefault(contribution.FormaColaboracion, DEFAULT_CONTRIBUTION)
            };

            await _contributionRepository.Insert(contributionEntity);
            return isNewUser;
        }
    }
}
