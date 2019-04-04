using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using TheCoreArchitecture.Data.Base;

namespace TheCoreArchitecture.Data.Entities
{
    [Table("Area")]
    public class Area : BaseLookUpEntity
    {
        [ForeignKey("Country")]
        public int CountryId { get; set; }
        public virtual Country Country { get; set; }

        public virtual ICollection<City> Cities { get; set; }
    }
}