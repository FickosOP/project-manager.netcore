using Microsoft.EntityFrameworkCore;
using ProjectManager.Contexts;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Implementation
{
    public class ReportRepository : Repository<Report>, IReportRepository
    {
        public ReportRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Report> FindAllInclude() 
        {
            return Entities
                    .Where(e => e.IsActive)
                    .Include(e => e.TeamMember)
                    .Include(e => e.Client)
                    .Include(e => e.Project)
                    .Include(e => e.Category)
                    .AsEnumerable();
        }

        public IEnumerable<Report> FindByDate(DateTime date)
        {
            return Entities
                    .Where(e => e.CreatedAt.Date == date.Date)
                    .AsEnumerable();
        }
    }
}
