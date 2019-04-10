using System.ComponentModel.DataAnnotations;

namespace TheCoreArchitecture.Service.Dto.Parameter
{
    public class CountryAddDto
    {
        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid input length")]
        public string CountryName { get; set; }
    }
}
