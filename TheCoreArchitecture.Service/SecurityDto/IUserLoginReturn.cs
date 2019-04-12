using System;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public interface IUserLoginReturn
    {
        string Token { get; set; }
        DateTime TokenValidTo { get; set; }
        string FirstName { get; set; }
        string LastName { get; set; }
        string UserId { get; set; }
    }
}
