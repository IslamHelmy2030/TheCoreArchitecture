using System.ComponentModel.DataAnnotations;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public class LoginParameter
    {
        [Required]
        public string UserName { get; set; }

        [Required, DataType(DataType.Password), MinLength(6, ErrorMessage = "Invalid Length")]
        public string Password { get; set; }
    }
}
