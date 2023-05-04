using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.DTOs
{
    public class ReportSearchDto
    {
        public Guid TeamMemberId { get; set; }
        public Guid ClientId { get; set; }
        public Guid ProjectId { get; set; }
        public Guid CategoryId { get; set; }
        public string StartDate { get; set; }
        public string EndDate { get; set; }
    }
}
