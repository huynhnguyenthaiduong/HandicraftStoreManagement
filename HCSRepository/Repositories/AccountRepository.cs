using HCSBO;
using HCSBO.DTOs.Accounts;
using HCSDAO;
using HCSRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSRepository.Repositories
{
    public class AccountRepository : IAccountRepository
    {
        public Account Login(string email, string password) => AccountDAO.Instance.Login(email, password);
        public Account Register(RegisteredAccount registerdAccount) => AccountDAO.Instance.Register(registerdAccount);

        public List<Account> GetPaginateResult(int page, int pageSize, string searchProperty, string searchValue) 
            => AccountDAO.Instance.GetPaginateResult(page, pageSize, searchProperty, searchValue);
        public List<Account> GetAllAccounts() => AccountDAO.Instance.GetAllAccounts();
        public List<Account> GetActiveAccounts() => AccountDAO.Instance.GetActiveAccounts();
        public Account GetAccountById(Guid id) => AccountDAO.Instance.GetAccountById(id);

        public void DeleteAccount(Guid accountId) => AccountDAO.Instance.DeleteAccount(accountId);
        public void ChangeAccountStatus(Guid accountId) => AccountDAO.Instance.ChangeAccountStatus(accountId);
        public void AddAccount(Account addedAccount) => AccountDAO.Instance.AddAccount(addedAccount);
        public void UpdateAccount(Account updatedAcc) => AccountDAO.Instance.UpdateAccount(updatedAcc);

        public List<Account> SearchAccounts(string searchProperty, string searchValue) 
            => AccountDAO.Instance.SearchAccounts(searchProperty, searchValue);
    }
}
