namespace TPDDSBackend.Domain.Entitites
{
    public class FoodDelivery : Contribution
    {
        public virtual Fridge OriginFridge { get; set; }
        public int OriginFridgeId { get; set; }
        public virtual Fridge DestinationFridge { get; set; }
        public int DestinationFridgeId { get; set; }
        public int Amount { get; set; }
        public virtual DeliveryReason DeliveryReason { get; set; }
        public int DeliveryReasonId { get; set; }

    }
}
