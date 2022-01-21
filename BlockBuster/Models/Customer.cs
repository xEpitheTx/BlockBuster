using System.ComponentModel.DataAnnotations;

namespace BlockBuster.Models
{
    public class Customer
    {
        public int Id { get; set; }
        [Required]
        [StringLength(255)]
        public string Name { get; set; }
        public bool IsSubscribed { get; set; }
        public MembershipType MembershipType { get; set; }
        public byte MembershipTypeID { get; set; }
    }
}
