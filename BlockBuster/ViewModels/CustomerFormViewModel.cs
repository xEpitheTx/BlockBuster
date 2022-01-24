using BlockBuster.Models;

namespace BlockBuster.ViewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType>? MembershipTypes { get; set; }

        public Customer Customer { get; set; }
    }
}
