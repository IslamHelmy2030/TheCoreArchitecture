using System.Collections.Generic;
using TheCoreArchitecture.Data.IdentityEntities;

namespace TheCoreArchitecture.Data.InitialDataInitializer
{
    public class DataInitializer : IDataInitializer
    {
        public List<ApplicationRole> GetInitialRoles()
        {
            return new List<ApplicationRole>
            {
                new ApplicationRole {Id = "1", Name = "Admin", NormalizedName = "ADMIN"},
                new ApplicationRole {Id = "2", Name = "User", NormalizedName = "USER"}
            };
        }
    }
}