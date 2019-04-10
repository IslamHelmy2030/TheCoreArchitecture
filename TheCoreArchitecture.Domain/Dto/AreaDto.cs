using System.ComponentModel.DataAnnotations;

namespace TheCoreArchitecture.Domain.Dto
{
    public class AreaDto
    {
        public int AreaId { get; set; }

        [Required(AllowEmptyStrings = false, ErrorMessage = "This field is required")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "Invalid input length")]
        public string AreaName { get; set; }
    }
}