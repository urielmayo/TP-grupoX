using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class CollaboratorCard
    {
        public DateTime LastModificationAt { get; set; }

        public DateTime CreatedAt { get; set; }

        public virtual Card Card { get; set; }

        public int CardId   { get; set; }

        public Collaborator Collaborator { get; set; }

        public string CollaboratorId {  get; set; }
    }
}
