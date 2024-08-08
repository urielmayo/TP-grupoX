using System.Diagnostics.Contracts;

namespace TPDDSBackend.Domain.Entitites
{
    public class FridgeOwner : Contribution
    {
        public Fridge Fridge { get; set; }
    }
}
