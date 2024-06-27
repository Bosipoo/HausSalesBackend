using Microsoft.AspNetCore.Identity;

namespace HausSalesBackend.Models
{
    public class ApplicationRole : IdentityRole
    {
        // Additional properties
        public string Description { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
