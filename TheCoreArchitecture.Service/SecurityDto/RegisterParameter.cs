using System.ComponentModel.DataAnnotations;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public class RegisterParameter : LoginParameter
    {
        [Required, DataType(DataType.EmailAddress,ErrorMessage = "Enter Invalid Email Address")]
        public string Email { get; set; }
        [StringLength(50,ErrorMessage = "Invalid Input Length")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "Invalid Input Length")]
        public string LastName { get; set; }
    }
}
