using System.ComponentModel.DataAnnotations;

namespace HausSalesBackend.Models
{
    public class Prospect
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string OtherNames { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string StateOfOrigin { get; set; }
        public string Phone { get; set; }
        public string MaritalStatus { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string EmploymentStatus { get; set; }
        public string PlaceOfWork { get; set; }
        public string CompanyAddress { get; set; }
        public string NextOfKinName { get; set; }
        public string NextOfKinAddress { get; set; }
        public string NextOfKinPhone { get; set; }
        public string NextOfKinRelationship { get; set; }
        public string AreasOfInterest { get; set; }
        public string RefererCompany { get; set; }
        public string LastCodeGenerated { get; set; }
        public string RefererIdentity { get; set; }
        public string RegCode { get; set; }
        public string ClientStatus { get; set; }
        public ICollection<Sale> Sales { get; set; }
    }

}
