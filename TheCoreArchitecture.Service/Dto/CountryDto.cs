using System.ComponentModel.DataAnnotations;

namespace TheCoreArchitecture.Service.Dto
{
    public class CountryDto
    {
        public int CountryId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid input length")]
        public string CountryName { get; set; }
    }
}
