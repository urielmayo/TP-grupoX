using System.ComponentModel.DataAnnotations.Schema;

namespace TPDDSBackend.Domain.Entitites
{
    public class Fridge : AuditableEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
        public decimal Longitud { get; set; }
        public decimal Latitud { get; set; }
        public DateTime SetUpAt { get; set; }
        public int MaxFoodCapacity { get; set; }
    }
}
