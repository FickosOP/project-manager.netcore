using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.DTOs
{
    public class TeamMemberDto
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public float HoursPerWeek { get; set; }
        public string Email { get; set; }
        public Role Role { get; set; }

        public TeamMemberDto(TeamMember teamMember)
        {
            Name = teamMember.Name;
            Username = teamMember.Username;
            HoursPerWeek = teamMember.HoursPerWeek;
            Email = teamMember.Email;
            Role = teamMember.Role;
        }
    }
}
