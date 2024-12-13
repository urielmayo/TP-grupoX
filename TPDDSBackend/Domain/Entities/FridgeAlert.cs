using TPDDSBackend.Domain.Enums;

namespace TPDDSBackend.Domain.Entities
{
    public class FridgeAlert: FridgeIncident
    {
        public TypeFridgeAlert Type { get; set; }
    }
}
