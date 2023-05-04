using Microsoft.EntityFrameworkCore;
using ProjectManager.Contexts;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Implementation
{
    public class TeamMemberRepository : Repository<TeamMember>, ITeamMemberRepository
    {
        public TeamMemberRepository(DatabaseContext context) : base(context) { }
        
        public override TeamMember FindById(Guid id)
        {
            return Entities
                    .Where(tm => tm.Id == id)
                    .Include(tm => tm.Role).SingleOrDefault();
        }
    }
}
