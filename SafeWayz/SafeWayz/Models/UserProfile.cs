using System;
using System.Collections.Generic;
using System.Text;

namespace SafeWayz.Models
{
    public class UserProfile
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public long UserToken { get; set; }
    }
}
