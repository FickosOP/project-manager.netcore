using ProjectManager.Models;
using ProjectManager.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Services
{
    public interface IAccountService : ICrudService<Account>
    {
        public TeamMember Login(CredentialsDto credentials);
        public bool ResetPassword(Guid teamMemberId);
        public bool ChangePassword(Guid teamMemberId, string oldPassword, string newPassword);
    }
}
