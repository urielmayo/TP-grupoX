﻿using TPDDSBackend.Domain.Entities;
using TPDDSBackend.Domain.Entitites;
using TPDDSBackend.Domain.Interfaces;

namespace TPDDSBackend.Aplication.Services.Strategies
{
    public class FoodContributionStrategy : IContributionStrategy
    {
        public Dictionary<string, object> GetAttributes(Contribution contribution)
        {
            var donation = (FoodDonation)contribution;
            return new Dictionary<string, object>
            {
                { "description", donation.Food.Description },
                { "expiration_date", donation.Food.ExpirationDate},
                { "state", donation.Food.State.Description},
                { "fridge", donation.Food.Fridge.Name},
                { "calories", donation.Food.Calories},
                { "weight", donation.Food.Weight},
                { "donee", donation.Collaborator.UserName },
                {"status", donation.Status.ToString() }
            };
        }

        public decimal GetPoints(Contribution contribution, BenefitCoefficients coefficients)
        {
            return coefficients.DonatedFoods;
        }
    }
}
