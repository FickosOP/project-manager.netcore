using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Models.DTOs
{
    public class ProjectDto
    {
        public Guid Id { get; set; }
        public Client Client { get; set; }
        public TeamMember Lead { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
    
        public ProjectDto(Project project)
        {
            Id = project.Id;
            Client = project.Client;
            Lead = project.Lead;
            Name = project.Name;
            Description = project.Description;
        }
    }
}
