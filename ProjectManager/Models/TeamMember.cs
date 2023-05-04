using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class TeamMember : EntityBase
    {
        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        [MaxLength(30)]
        public string Username { get; set; }
        [Required]
        [Range(0, 84)]
        public float HoursPerWeek { get; set; }
        [Required]
        [MinLength(6)]
        [MaxLength(50)]
        public string Email { get; set; }
        [ForeignKey("Role")]
        public Guid RoleId { get; set; }
        public Role Role { get; set; }
    }
}
