using Microsoft.AspNetCore.Identity;

namespace TheCoreArchitecture.Data.IdentityEntities
{
    public class ApplicationUserLogin : IdentityUserLogin<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}