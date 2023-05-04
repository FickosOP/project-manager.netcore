using Microsoft.EntityFrameworkCore;
using ProjectManager.Contexts;
using ProjectManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace ProjectManager.Repositories.Implementation
{
    public class AccountRepository : Repository<Account>, IAccountRepository
    {
        public AccountRepository(DatabaseContext context) : base(context) { }

        public IEnumerable<Account> FindAllInclude()
        {
            return Entities
                    .Where(e => e.IsActive)
                    .Include(e => e.TeamMember)
                    .AsEnumerable();
        }

        public override Account Save(Account account)
        {
            string encryptedPassword = EncryptData(account.Password);
            account.Password = encryptedPassword;
            Entities.Add(account);
            Context.SaveChanges();
            return account;
        }

        public override Account Edit(Account account)
        {
            Account existing = FindById(account.Id);
            if (existing != null)
            {
                string encryptedPassword = EncryptData(account.Password);
                account.Password = encryptedPassword;
                Context.Entry(existing).CurrentValues.SetValues(account);
                Context.SaveChanges();
                return account;
            }
            return null;
        }

        public Account FindByTeamMemberId(Guid id)
        {
            return Entities
                    .SingleOrDefault(e => e.TeamMemberId == id);
        }

        public string EncryptData(string data)
        {
            string GenerateSalt()
            {
                RNGCryptoServiceProvider crypto = new RNGCryptoServiceProvider();
                byte[] salt = new byte[32];
                crypto.GetBytes(salt);
                return Convert.ToBase64String(salt);
            }
            string EncryptValue(string value)
            {
                string saltValue = GenerateSalt();
                byte[] saltedPassword = Encoding.UTF8.GetBytes(saltValue + value);
                using (SHA256Managed sha = new SHA256Managed())
                {
                    byte[] hash = sha.ComputeHash(saltedPassword);
                    return $"{Convert.ToBase64String(hash)}:{saltValue}";
                }
            }
            return EncryptValue(data);
        }
    }
}
