
using System;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public class UserLoginReturn : IUserLoginReturn
    {
        public string Token { get; set; }
        public DateTime TokenValidTo { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserId { get; set; }
    }
}
