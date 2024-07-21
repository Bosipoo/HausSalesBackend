namespace HausSalesBackend.Models.DTOs
{
    public class PropertyDto
    {
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
        public int PropertyTypeId { get; set; }
    }

}
