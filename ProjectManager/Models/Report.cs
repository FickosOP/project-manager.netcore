using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models
{
    public class Report : EntityBase
    {
        [ForeignKey("Client")]
        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        [ForeignKey("Project")]
        public Guid ProjectId { get; set; }
        public Project Project { get; set; }

        [ForeignKey("TeamMember")]
        public Guid TeamMemberId { get; set; }
        public TeamMember TeamMember { get; set; }

        [ForeignKey("Category")]
        public Guid CategoryId { get; set; }
        public Category Category { get; set; }

        [Required]
        public float Time { get; set; }

        public float Overtime { get; set; } = 0;

        [MaxLength(100)]
        public string Description { get; set; }

    }
}
