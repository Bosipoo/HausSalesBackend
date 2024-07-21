using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HausSalesBackend.Models
{
    public class Property
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public Guid SSID { get; set; }

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

        [ForeignKey("PropertyType")]
        public int PropertyTypeId { get; set; }
        public PropertyType PropertyType { get; set; } = null!;
    }

}
