using System.ComponentModel.DataAnnotations;

namespace BlockBuster.Models
{
    public class Minimum18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            Customer customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeID == MembershipType.Unknown || customer.MembershipTypeID == MembershipType.PayAsYouGo)
            {
                return ValidationResult.Success;
            }
            
            if (customer.Birthdate == null)
            {
                return new ValidationResult("Date of Birth is required.");
            }

            var age = DateTime.Today.Year - customer.Birthdate.Value.Year;

                return (age >= 18) 
                ? ValidationResult.Success 
                : new ValidationResult("Customers must be 18 or older to go on a membership.");
        }
    }
}
