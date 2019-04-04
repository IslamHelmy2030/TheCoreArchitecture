using System.ComponentModel.DataAnnotations;

namespace TheCoreArchitecture.Data.Base
{
    public class BaseLookUpEntity : BaseEntity
    {
        [MaxLength(50)]
        public string Name { get; set; }
    }
}
