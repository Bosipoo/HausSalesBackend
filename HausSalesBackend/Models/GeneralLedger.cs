using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HausSalesBackend.Models
{
    public class GeneralLedger
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid glId { get; set; }  // Change this to Guid if it was string

        [Required]
        public string accountNumber { get; set; }

        [Required]
        public string glGroupId { get; set; }

        [Required]
        public string glTypeId { get; set; }

        [Required]
        public string tempAccName { get; set; }

        [Required]
        public string glAccDescription { get; set; }

        [Required]
        public string glAccName { get; set; }

    }
}
