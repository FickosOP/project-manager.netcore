using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.DTOs
{
    public class ReportDto
    {
        public Guid Id { get; set; }
        public DateTime Date { get; set; }
        public string TeamMemberName { get; set; }
        public string ProjectName { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }

        public ReportDto(Report report)
        {
            Id = report.Id;
            Date = report.CreatedAt;
            TeamMemberName = report.TeamMember.Name;
            ProjectName = report.Project.Name;
            Category = report.Category;
            Description = report.Description;
        }
    }
}
