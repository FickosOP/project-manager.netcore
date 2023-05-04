using ProjectManager.Contexts;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Implementation
{
    public class ClientRepository : Repository<Client>, IClientRepository
    {
        public ClientRepository(DatabaseContext context) : base(context) { }
    }
}
