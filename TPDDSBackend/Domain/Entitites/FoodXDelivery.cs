using Microsoft.AspNetCore.Authentication;

namespace TPDDSBackend.Domain.Entitites
{
    public class FoodXDelivery : AuditableEntity
    {
        public Food Food { get; set; }
        public FoodDelivery Delivery { get; set; }
    }
}
