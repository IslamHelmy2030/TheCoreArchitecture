
using System;

namespace TheCoreArchitecture.Service.SecurityDto
{
    public class UserLoginReturn : IUserLoginReturn
    {
        public string Token { get; set; }
        public DateTime TokenValidTo { get; set; }
        public string FullName { get; set; }
    }
}
