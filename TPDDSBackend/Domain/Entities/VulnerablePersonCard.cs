using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class VulnerablePersonCard: Contribution
    {
        public virtual Card Card { get; set; }
        public int CardId { get; set; }
        public virtual PersonInVulnerableSituation Owner { get; set; }
        public int PersonInVulnerableSituationId { get; set; }
    }
}
