using HCSBO;
using HCSBO.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSDAO
{
    public class AccountDAO
    {
        private readonly HCStoreManagementContext dbContext = null;

        private static AccountDAO instance = null;
        public static AccountDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new AccountDAO();
                }
                return instance;
            }
        }

        public AccountDAO()
        {
            if (dbContext == null)
                dbContext = new HCStoreManagementContext();
        }

        #region CRUDFunction
        public List<Account> GetPaginateResult(int page, int pageSize, string searchProperty, string searchValue)
        {
            List<Account> result = new List<Account>();
            if (string.IsNullOrEmpty(searchProperty) || string.IsNullOrEmpty(searchValue))
            {
                result = GetAllAccounts();
            }
            else
            {
                result = SearchAccounts(searchProperty, searchValue);
            }

            return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Account> GetAllAccounts()
        {
            return dbContext.Accounts.ToList();
        }

        public List<Account> GetActiveAccounts()
        {
            return dbContext.Accounts.Where(a => a.Status == true).ToList();
        }

        public Account GetAccountById(Guid id)
        {
            return dbContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(id));
        }

        public List<Account> SearchAccounts(string searchProperty, string searchValue)
        {
            List<Account> result = new List<Account>();
            switch (searchProperty)
            {
                case "UserName":
                    result = dbContext.Accounts.Where(a => a.UserName.Contains(searchValue)).ToList();
                    break;
                case "FullName":
                    result = dbContext.Accounts.Where(a => a.FullName.Contains(searchValue)).ToList();
                    break;
                case "Email":
                    result = dbContext.Accounts.Where(a => a.Email.Contains(searchValue)).ToList();
                    break;
            }
            return result;
        }

        public void AddAccount(Account addedAccount)
        {
            Account account = dbContext.Accounts.Where(a => a.Email.Equals(addedAccount.Email)).FirstOrDefault();

            if (account == null)
            {
                dbContext.Accounts.Add(addedAccount);
                dbContext.SaveChanges();
            }
        }

        public void UpdateAccount(Account updatedAcc)
        {
            Account account = dbContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(updatedAcc.AccountId));

            if (account != null)
            {
                dbContext.Entry(account).CurrentValues.SetValues(updatedAcc);
                dbContext.SaveChanges();
            }
        }

        public void ChangeAccountStatus(Guid accountId)
        {
            Account account = dbContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(accountId));

            if (account != null)
            {
                account.Status = !account.Status;
                dbContext.Entry(account).CurrentValues.SetValues(account);
                dbContext.SaveChanges();
            }
        }

        public void DeleteAccount(Guid accountId)
        {
            Account account = dbContext.Accounts.FirstOrDefault(a => a.AccountId.Equals(accountId));

            if (account != null)
            {
                dbContext.Remove<Account>(account);
                dbContext.SaveChanges();
            }
        }
        #endregion

        #region AuthFunction
        public Account Login(string email, string password)
        {
            return dbContext.Accounts.Where(a => a.Email.Equals(email) &&
                                                 a.Password.Equals(password))
                                     .FirstOrDefault();
        }

        public Account Register(RegisteredAccount registerdAccount)
        {
            Account account = dbContext.Accounts.Where(a => a.Email.Equals(registerdAccount.Email)).FirstOrDefault();

            if (account == null)
            {
                Account newAcc = new Account
                {
                    AccountId = Guid.NewGuid(),
                    RoleId = RoleDAO.Instance.GetRoleIdByName("User"),
                    UserName = registerdAccount.UserName,
                    Password = registerdAccount.Password,
                    FullName = registerdAccount.FullName,
                    Email = registerdAccount.Email,
                    Gender = registerdAccount.Gender,
                    PhoneNumber = registerdAccount.PhoneNumber,
                    Address = registerdAccount.Address,
                    Status = true
                };

                dbContext.Accounts.Add(newAcc);
                dbContext.SaveChanges();
                return newAcc;
            }

            return null;
        }
        #endregion
    }
}
