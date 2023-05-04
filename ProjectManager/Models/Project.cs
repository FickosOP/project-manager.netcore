using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class Project : EntityBase
    {
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Lead")]
        public Guid LeadId { get; set; }
        public TeamMember Lead { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(80)]
        public string Name { get; set; }

        [MaxLength(500)]
        public string Description { get; set; }
  
    }
}
