using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerAPI.Models
{
    public class UserAuthObject
    {
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Expires { get; set; }
    }

    public class UserRolesObject
    {
        public string UserName { get; set; }
        public List<string> Roles { get; set; }
    }

    public class PolicyAuthObject
    {
        public string PolicyName { get; set; }
        public List<UserRolesObject> UserRoles { get; set; }
        public string Issuer { get; set; }
        public string Key { get; set; }
    }
}
