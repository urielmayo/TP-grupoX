using System.Diagnostics.Contracts;

namespace TPDDSBackend.Domain.Entitites
{
    public class FridgeOwner : Contribution
    {
        public virtual Fridge Fridge { get; set; }
        public int FridgeId { get; set; }
    }
}
