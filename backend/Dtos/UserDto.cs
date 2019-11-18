using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MentorOnDemand.Dtos
{
    public class UserDto
    {
        public string id { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Skill { get; set; }
        public string Experience { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public bool Active { get; set; }


    }
}
