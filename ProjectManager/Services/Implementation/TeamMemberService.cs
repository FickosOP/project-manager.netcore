using ProjectManager.Models;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class TeamMemberService : CrudService<TeamMember>, ITeamMemberService
    {
        public TeamMemberService(ITeamMemberRepository repository) : base(repository) { }
    }
}
