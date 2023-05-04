using Microsoft.EntityFrameworkCore;
using ProjectManager.Contexts;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Implementation
{
    public class RoleRepository : IRoleRepository
    {
        private readonly DatabaseContext Context;
        private DbSet<Role> Roles;
        public RoleRepository(DatabaseContext context)
        {
            Context = context;
            Roles = context.Set<Role>();
        }
        public IEnumerable<Role> FindAll()
        {
            return Roles.AsEnumerable();
        }

        public Role FindById(Guid id)
        {
            return FindAll().SingleOrDefault(role => role.Id == id);
        }

        public Role Save(Role role)
        {
            Roles.Add(role);
            Context.SaveChanges();
            return role;
        }
    }
}
