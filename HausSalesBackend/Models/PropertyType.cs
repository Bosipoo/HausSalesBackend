using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HausSalesBackend.Models
{
    public class PropertyType
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty!;
        public string Code { get; set; } = string.Empty!;
        public int NoOfUnits { get; set; }
        public int NoOfFractionsPerUnit { get; set; }
        public string TypeDescription { get; set; } = string.Empty!;
    }
}
