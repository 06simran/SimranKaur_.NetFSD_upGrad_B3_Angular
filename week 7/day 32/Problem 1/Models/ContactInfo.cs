using System.ComponentModel.DataAnnotations;

namespace WebApplication20.Models
{
    public class ContactInfo
    {
        [Required(ErrorMessage = "Contact ID is required")]
        public int ContactId { get; set; }

        [Required(ErrorMessage = "First Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "First Name cannot contain numbers or special characters")]
        public string FirstName { get; set; }

        [Required(ErrorMessage = "Last Name is required")]
        [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "Last Name cannot contain numbers or special characters")]
        public string LastName { get; set; }

        public string CompanyName { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Enter a valid email address")]
        public string EmailId { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Mobile Number must be exactly 10 digits")]
        public string MobileNo { get; set; }  
        public string Designation { get; set; }
    }
}