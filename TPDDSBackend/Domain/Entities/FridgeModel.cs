using TPDDSBackend.Domain.Entitites;

namespace TPDDSBackend.Domain.Entities
{
    public class FridgeModel: AuditableEntity
    {
        public string Name { get; set; }
        public float MaxTemperature {  get; set; }
        public float MinTemperature { get; set; }
    }
}
