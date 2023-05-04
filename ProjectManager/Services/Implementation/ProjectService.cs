using ProjectManager.Models;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class ProjectService : CrudService<Project>, IProjectService
    {
        public ProjectService(IProjectRepository repository) : base(repository) { }

        public IEnumerable<Project> FindAllInclude()
        {
            IProjectRepository repository = Repository as IProjectRepository;
            return repository.FindAllInclude();
        }

        public IEnumerable<Project> Search(string name)
        {
            IProjectRepository repository = Repository as IProjectRepository;
            return repository
                    .FindAllInclude()
                    .Where(project => project.Name.ToUpper().StartsWith(name.ToUpper()));
        }
    }
}
