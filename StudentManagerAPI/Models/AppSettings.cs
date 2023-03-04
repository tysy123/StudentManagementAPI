using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentManagerAPI.Models
{
    public class AppSettings
    {
        public ConnectionStrings connectionStrings { get; set; }
        public Jwt jwt { get; set; }
        public List<UserAuthObject> UserAuth { get; set; }
        public List<PolicyAuthObject> PolicyAuth { get; set; }
    }
    public class Jwt
    {
        public string Key { get; set; }
        public string Issuer { get; set; }
    }
    public class ConnectionStrings
    {
        public string Connection { get; set; }        
    }
}
