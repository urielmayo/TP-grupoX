using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TPDDSBackend.Domain.Enums;
using TPDDSBackend.Infrastructure.Repositories;

namespace TPDDSBackend.Domain.Entitites
{
    public class Collaborator : IdentityUser
    {
        public string? Address { get; set; }
        public DateTime LastModificationAt { get; set; }
        public DateTime CreatedAt { get; set; }

        public string Discriminator { get; set; }

        public virtual async Task<MoneyDonation> DonateMoney(decimal amount, DateTime date, DonationFrequency frequency)=>
         new MoneyDonation 
            {
                Amount = amount, 
                Frequency = frequency,
                Date = date,
                CollaboratorId = Id
            };
        
    }
}
