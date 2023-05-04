using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services
{
    public interface IProjectService : ICrudService<Project>
    {
        public IEnumerable<Project> FindAllInclude();
        public IEnumerable<Project> Search(string name);
    }
}
