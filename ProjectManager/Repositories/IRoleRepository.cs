using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories
{
    public interface IRoleRepository
    {
        IEnumerable<Role> FindAll();
        Role FindById(Guid id);
        Role Save(Role role);
    }
}
