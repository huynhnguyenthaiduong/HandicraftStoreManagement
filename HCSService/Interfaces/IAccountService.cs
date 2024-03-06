using HCSBO;
using HCSBO.DTOs.Accounts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSService.Interfaces
{
    public interface IAccountService
    {
        public Account Login(string email, string password);
        public Account Register(RegisteredAccount registerdAccount);

        public List<Account> GetPaginateResult(int page, int pageSize, string searchProperty, string searchValue);
        public List<Account> GetAllAccounts();
        public List<Account> GetActiveAccounts();
        public Account GetAccountById(Guid id);

        public void DeleteAccount(Guid accountId);
        public void ChangeAccountStatus(Guid accountId);
        public void AddAccount(Account addedAccount);
        public void UpdateAccount(Account updatedAcc);

        public List<Account> SearchAccounts(string searchProperty, string searchValue);
    }
}
