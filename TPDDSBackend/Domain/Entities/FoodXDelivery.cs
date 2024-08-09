using Microsoft.AspNetCore.Authentication;

namespace TPDDSBackend.Domain.Entitites
{
    public class FoodXDelivery : AuditableEntity
    {
        public virtual Food Food { get; set; }

        public int FoodId { get; set; }
        public virtual FoodDelivery Delivery { get; set; }
        public int DeliveryId { get; set; }
    }
}
