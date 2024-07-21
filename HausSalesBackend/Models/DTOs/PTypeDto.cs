using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace HausSalesBackend.Models.DTOs
{
    public class PTypeDto
    {
        public string Name { get; set; }
        public string Code { get; set; }
        public int NoOfUnits { get; set; }
        public int NoOfFractionsPerUnit { get; set; }
        public string TypeDescription { get; set; }
    }
}
