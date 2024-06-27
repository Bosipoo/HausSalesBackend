using System.ComponentModel.DataAnnotations;

namespace HausSalesBackend.Models
{
    public class SalesRepresentative
    {
        [Key]
        public int Id { get; set; }

        public string FirstName { get; set; } = string.Empty!;
        public string LastName { get; set; } = string.Empty!;
        public string OtherNames { get; set; } = string.Empty!;
        public byte[] PPhoto { get; set; } = Array.Empty<byte>();
        public DateTime Dob { get; set; }
        public string Gender { get; set; } = string.Empty!;
        public string State { get; set; } = string.Empty!;
        public string Phone1 { get; set; } = string.Empty!;
        public string Phone2 { get; set; } = string.Empty!;
        public string Email { get; set; } = string.Empty!;
        public DateTime DateOfRecruitment { get; set; }
        public string Address { get; set; } = string.Empty!;
        public string NokName { get; set; } = string.Empty!;
        public string NokAddress { get; set; } = string.Empty!;
        public string NokPhone { get; set; } = string.Empty!;
        public string NokRelationship { get; set; } = string.Empty!;
        public string RidName { get; set; } = string.Empty!;
        public string RidAffiliateCompany { get; set; } = string.Empty!;
        public string RidBeneficiaryDetails { get; set; } = string.Empty!;
        public string LhaName { get; set; } = string.Empty!;
        public string LhaBankName { get; set; } = string.Empty!;
        public string LhaUplink { get; set; } = string.Empty!;
        public string LhaAccountNumber { get; set; } = string.Empty!;
    }
}
