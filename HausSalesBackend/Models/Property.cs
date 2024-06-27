using System.ComponentModel.DataAnnotations;

namespace HausSalesBackend.Models
{
    public class Property
    {
        [Key]
        public int Id { get; set; }

        public int SSID { get; set; }
        public string ProjectCode { get; set; } = string.Empty!;
        public string Description { get; set; } = string.Empty!;
        public string Address { get; set; } = string.Empty!;
        public decimal OffPlanTrancheDisc { get; set; }
        public decimal OffPlanBulletDisc { get; set; }
        public decimal ConstructionStageDisc { get; set; }
        public decimal NoDiscount { get; set; }
        public decimal PricePerFraction { get; set; }
        public int NoOfFractions { get; set; }
        public string Moniker { get; set; } = string.Empty!;
        public bool Active { get; set; }
        public string TypeName { get; set; } = string.Empty!;
        public string TypeCode { get; set; } = string.Empty!;
        public int NoOfUnits { get; set; }
        public int NoOfFractionsPerUnit { get; set; }
        public string TypeDescription { get; set; } = string.Empty!;
    }
}
