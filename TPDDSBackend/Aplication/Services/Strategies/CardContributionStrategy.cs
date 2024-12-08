using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class CardContributionStrategy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (VulnerablePersonCard)contribution;
            return new Dictionary<string, object>
            {
                { "name", donation.Owner.Name },
                { "surname", donation.Owner.Surname },
                { "birthdate", donation.Owner.BirthDate },
                { "address", donation.Owner.Address },
                { "card", donation.Card.Code },
                { "minors_in_care", donation.Owner.MinorsInCare },
                { "doc_type", donation.Owner.DocumentType.Description },
                { "doc_number", donation.Owner.DocumentNumber }
            };
        }

        public decimal GetPoints(Contribution contribution, BenefitCoefficients coefficients)
        {
            return coefficients.DeliveredCards;
        }
    }
}
