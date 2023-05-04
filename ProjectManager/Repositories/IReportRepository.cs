using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories
{
    public interface IReportRepository : IRepository<Report>
    {
        public IEnumerable<Report> FindAllInclude();
        public IEnumerable<Report> FindByDate(DateTime date);
    }
}
