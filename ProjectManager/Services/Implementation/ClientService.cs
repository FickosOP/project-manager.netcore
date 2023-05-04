using ProjectManager.Models;
using ProjectManager.Repositories;
using ProjectManager.Repositories.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class ClientService : CrudService<Client>, IClientService
    {
        public ClientService(IClientRepository repository) : base(repository) { }

        public IEnumerable<Client> Search(string name)
        {
            return Repository
                    .FindAll()
                    .Where(client => client.Name.ToUpper().StartsWith(name.ToUpper()));
        }
    }
}
