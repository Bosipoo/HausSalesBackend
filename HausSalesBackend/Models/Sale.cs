namespace HausSalesBackend.Models
{
    public class Sale
    {

        public int Id { get; set; }
        public string SalesId { get; set; }
        public string SalesRefNo { get; set; }
        public int ProspectId { get; set; } // Foreign key to Prospect
        public Prospect Prospect { get; set; } // Navigation property
        public int PurchaseQty { get; set; }
        public string Project { get; set; }
        public decimal PriceComp { get; set; }
        public decimal FractionPrice { get; set; }
        public int AvailFractions { get; set; }
        public decimal AmtPaid { get; set; }
        public string DiscountType { get; set; }
        public decimal OutstandingBal { get; set; }
        public string Notes { get; set; }
    }
}
