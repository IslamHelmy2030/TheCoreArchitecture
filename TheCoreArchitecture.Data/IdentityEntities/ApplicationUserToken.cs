using Microsoft.AspNetCore.Identity;

namespace TheCoreArchitecture.Data.IdentityEntities
{
    public class ApplicationUserToken : IdentityUserToken<string>
    {
        public virtual ApplicationUser User { get; set; }
    }
}