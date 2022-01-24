using BlockBuster.Models;
using System.ComponentModel.DataAnnotations;

namespace BlockBuster.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType>? MembershipTypes { get; set; }

        public int? Id { get; set; }

        [Required]
        [StringLength(255)]
        public string Name { get; set; }

        public bool IsSubscribed { get; set; }

        [Display(Name = "Membership Type")]
        public byte? MembershipTypeID { get; set; }

        [Minimum18YearsIfAMember]
        [Display(Name = "Date of Birth")]
        public DateTime? Birthdate { get; set; }

        public string Title
        {
            get
            {
                return Id != 0 ? "Edit Customer" : "New Customer";
            }
        }
        public CustomerFormViewModel()
        {
            Id = 0;
        }

        public CustomerFormViewModel(Customer customer)
        {
            Id = customer.Id;
            Name = customer.Name;
            IsSubscribed = customer.IsSubscribed;
            MembershipTypeID = customer.MembershipTypeID;
            Birthdate = customer.Birthdate;
        }
    }
}
