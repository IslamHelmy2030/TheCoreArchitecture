using System;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public interface IUserLoginReturn
    {
        string Token { get; set; }
        DateTime TokenValidTo { get; set; }
        string FullName { get; set; }
    }
}
