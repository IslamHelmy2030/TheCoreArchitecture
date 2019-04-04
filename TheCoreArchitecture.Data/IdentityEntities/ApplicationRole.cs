using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;

namespace TheCoreArchitecture.Data.IdentityEntities
{
    public class ApplicationRole : IdentityRole
    {
        public string Description { get; set; }

        public virtual ICollection<ApplicationUserRole> UserRoles { get; set; }
        public virtual ICollection<ApplicationRoleClaim> RoleClaims { get; set; }
    }
}