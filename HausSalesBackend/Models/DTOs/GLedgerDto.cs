using System.ComponentModel.DataAnnotations;

namespace HausSalesBackend.Models.DTOs
{
    public class GLedgerDto
    {
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
        [Required]
        public bool status { get; set; }
    }
}
