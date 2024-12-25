using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class FridgeFailure: FridgeIncident
    {
        public virtual Collaborator Collaborator { get; set; }

        public required string CollaboratorId { get; set; }

        public required string Description { get; set; }

        public byte[]? Image { get; set; }
    }
}
