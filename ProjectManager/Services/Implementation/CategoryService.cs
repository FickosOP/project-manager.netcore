using ProjectManager.Models;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class CategoryService : CrudService<Category>, ICategoryService
    {
        public CategoryService(ICategoryRepository repository) : base(repository) { }

        public IEnumerable<Category> Search(string name)
        {
            ICategoryRepository repository = Repository as ICategoryRepository;
            return repository
                    .FindAll()
                    .Where(category => category.Name.ToUpper().StartsWith(name.ToUpper()));
        }
    }
}
