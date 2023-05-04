using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services
{
    public interface IClientService : ICrudService<Client>
    {
        public IEnumerable<Client> Search(string name);
    }
}
