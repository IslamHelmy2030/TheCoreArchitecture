using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TheCoreArchitecture.Data.IdentityEntities;

namespace TheCoreArchitecture.Data.InitialDataInitializer
{
    public interface IDataInitializer
    {
        List<ApplicationRole> GetInitialRoles();
    }
}
