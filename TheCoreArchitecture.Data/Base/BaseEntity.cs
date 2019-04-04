using System.ComponentModel.DataAnnotations;

namespace TheCoreArchitecture.Data.Base
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
