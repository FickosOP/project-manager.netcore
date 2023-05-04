using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services
{
    public interface ICategoryService : ICrudService<Category>
    {
        public IEnumerable<Category> Search(string name);
    }
}
