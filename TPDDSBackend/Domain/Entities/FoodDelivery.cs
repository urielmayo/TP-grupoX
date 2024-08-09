namespace TPDDSBackend.Domain.Entitites
{
    public class FoodDelivery : Contribution
    {
        public Fridge OriginFridge { get; set; }
        public Fridge DestinationFridge { get; set; }
        public int Amount { get; set; }
        public DeliveryReason DeliveryReason { get; set; }

    }
}
