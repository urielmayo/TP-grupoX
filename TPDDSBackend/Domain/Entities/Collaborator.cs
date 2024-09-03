using Microsoft.AspNetCore.Identity;

namespace TPDDSBackend.Domain.Entitites
{
    public class Collaborator : IdentityUser
    {
        public string? Address { get; set; }
        public DateTime LastModificationAt { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
