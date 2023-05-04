using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories
{
    public interface IProjectRepository : IRepository<Project>
    {
        public IEnumerable<Project> FindAllInclude();
    }
}
