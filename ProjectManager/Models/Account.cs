using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class Account : EntityBase
    {
        [Required]
        [MinLength(4)]
        [MaxLength(18)]
        public string Username { get; set; }

        [Required]
        [MinLength(4)]
        public string Password { get; set; } = "ch4ng3m3";

        [ForeignKey("TeamMember")]
        public Guid TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }
    }
}
