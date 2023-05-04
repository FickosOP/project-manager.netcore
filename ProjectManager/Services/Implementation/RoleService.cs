using ProjectManager.Models;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository Repository;

        public RoleService(IRoleRepository repository)
        {
            Repository = repository;
        }

        public IEnumerable<Role> FindAll()
        {
            return Repository.FindAll();
        }

        public Role FindById(Guid id)
        {
            return Repository.FindById(id);
        }

        public Role Save(Role role)
        {
            return Repository.Save(role);
        }
    }
}
