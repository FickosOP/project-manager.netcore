using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories
{
    public interface IAccountRepository : IRepository<Account>
    {
        public IEnumerable<Account> FindAllInclude();
        public Account FindByTeamMemberId(Guid id);
    }
}
