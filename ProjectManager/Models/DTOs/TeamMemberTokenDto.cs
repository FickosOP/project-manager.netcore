using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.DTOs
{
    public class TeamMemberTokenDto
    {
        public TeamMember TeamMember { get; set; }
        public string Token { get; set; }
    }
}
