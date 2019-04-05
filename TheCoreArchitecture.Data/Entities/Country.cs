using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TheCoreArchitecture.Data.Base;

namespace TheCoreArchitecture.Data.Entities
{
    [Table("Country")]
    public class Country : BaseLookUpEntity
    {
        public virtual ICollection<Area> Areas { get; set; }
    }
}
