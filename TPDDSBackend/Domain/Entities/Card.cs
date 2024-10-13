using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class Card: Contribution
    {
        public string Code { get; set; }
        public virtual PersonInVulnerableSituation Owner { get; set; }
        public int PersonInVulnerableSituationId { get; set; }
    }
}
