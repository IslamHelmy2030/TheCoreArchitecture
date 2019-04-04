using Microsoft.AspNetCore.Identity;

namespace TheCoreArchitecture.Data.IdentityEntities
{
    public class ApplicationRoleClaim : IdentityRoleClaim<string>
    {
        public virtual ApplicationRole Role { get; set; }
    }
}