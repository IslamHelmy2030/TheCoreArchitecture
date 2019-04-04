using System.ComponentModel.DataAnnotations.Schema;
using TheCoreArchitecture.Data.Base;

namespace TheCoreArchitecture.Data.Entities
{
    [Table("City")]
    public class City : BaseLookUpEntity
    {
        [ForeignKey("Area")]
        public int AreaId { get; set; }
        public virtual Area Area { get; set; }
    }
}