using System.ComponentModel.DataAnnotations;

namespace Pikia.APIs.DTOs
{
    public class RegisterDto
    {
        [Required]
        public string DisplayName { get; set; }

        [Phone]
        public string PhoneNumber { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [RegularExpression("^(?=.*[a-z])(?=.*[A-Z])(?=.*\\d)(?=.*[@$!%*?&])[A-Za-z\\d@$!%*?&]{8,10}$" ,
             ErrorMessage = "password must have 8 to 10 characters, at least 1 uppercase letter, 1 lowercase letter, 1 number and 1 special character")]
        public string Password { get; set; }
       
        public string Country { get; set; }
        public string City { get; set; }
        public string Street { get; set; }


    }
}
