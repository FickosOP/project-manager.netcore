using ProjectManager.Exceptions;
using ProjectManager.Models;
using ProjectManager.Models.DTOs;
using ProjectManager.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Services.Implementation
{
    public class AccountService : CrudService<Account>, IAccountService
    {
        private readonly IRepository<TeamMember> TeamMemberRepository;
        public AccountService(IAccountRepository repository, IRepository<TeamMember> teamMemberRepository) : base(repository) 
        {
            TeamMemberRepository = teamMemberRepository;
        }

        public override Account Save(Account account)
        {
            if(account.TeamMember is not null)
            {
                TeamMemberRepository.Save(account.TeamMember);
            }
            if(account != null && !UsernameExists(account))
            {
                account.Id = Guid.NewGuid();
                return Repository.Save(account);
            }
            throw new Exception($"Username: {account.Username} already exists.");
        }

        public TeamMember Login(CredentialsDto credentials)
        {
            IAccountRepository accountRepository = Repository as IAccountRepository;
            IEnumerable<Account> accounts = accountRepository.FindAllInclude();
            Account required =
                accounts.SingleOrDefault(
                    account => ValidateEncryptedData(credentials, account));
            if(required is null)
            {
                throw new CredentialsDontMatchException();
            }
            return required.TeamMember;
        }

        public bool ResetPassword(Guid teamMemberId)
        {
            IAccountRepository accountRepository = Repository as IAccountRepository;
            Account account = accountRepository.FindByTeamMemberId(teamMemberId);
            if(account != null)
            {
                account.Password = "ch4ng3m3";
                accountRepository.Edit(account);
                return true;
            }
            return false;
        }
        public bool ChangePassword(Guid teamMemberId, string oldPassword, string newPassword)
        {
            IAccountRepository accountRepository = Repository as IAccountRepository;
            Account account = accountRepository.FindByTeamMemberId(teamMemberId);
            CredentialsDto newCredentials = new CredentialsDto()
            {
                Username = account.Username,
                Password = oldPassword
            };
            if(account != null && ValidateEncryptedData(newCredentials, account))
            {
                account.Password = newPassword;
                accountRepository.Edit(account);
                return true;
            }
            return false;
        }

        private bool UsernameExists(Account account)
        {
            return Repository.FindAll()
                    .FirstOrDefault(acc => acc.Username.Equals(account.Username)) != null;
        }

        private bool ValidateEncryptedData(CredentialsDto dataToValidate, Account valueFromDatabase)
        {
            if (!dataToValidate.Username.Equals(valueFromDatabase.Username))
            {
                return false;
            }
            string[] values = valueFromDatabase.Password.Split(':');
            string encryptedValue = values[0];
            string salt = values[1];
            byte[] saltedValue = Encoding.UTF8.GetBytes(salt + dataToValidate.Password);

            using (var sha = new SHA256Managed())
            {
                byte[] hash = sha.ComputeHash(saltedValue);
                string valueToValidate = Convert.ToBase64String(hash);
                return encryptedValue.Equals(valueToValidate);
            }
        }
    }
}
