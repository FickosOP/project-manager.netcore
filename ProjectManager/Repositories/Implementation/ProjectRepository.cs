using Microsoft.EntityFrameworkCore;
using ProjectManager.Contexts;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Implementation
{
    public class ProjectRepository : Repository<Project>, IProjectRepository
    {
        public ProjectRepository(DatabaseContext context) : base(context) { }
        public IEnumerable<Project> FindAllInclude()
        {
            return Entities
                    .Where(e => e.IsActive)
                    .Include(e => e.Lead)
                    .Include(e => e.Client)
                    .AsEnumerable();
        }
        public override IEnumerable<Project> FindPage(int index, int count)
        {
            return Entities
                    .Where(e => e.IsActive)
                    .Include(e => e.Lead)
                    .Include(e => e.Client)
                    .OrderBy(e => e.CreatedAt)
                    .Skip((index - 1) * count)
                    .Take(count)
                    .AsEnumerable();
        }
    }
}
