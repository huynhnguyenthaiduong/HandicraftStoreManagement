using HCSBO;
using HCSBO.DTOs.Accounts;
using HCSRepository.Interfaces;
using HCSRepository.Repositories;
using HCSService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSService.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountRepository _accountRepository = null;

        public AccountService()
        {
            if (_accountRepository == null)
                _accountRepository = new AccountRepository();
        }

        public Account Login(string email, string password) => _accountRepository.Login(email, password);
        public Account Register(RegisteredAccount registerdAccount) => _accountRepository.Register(registerdAccount);

        public List<Account> GetPaginateResult(int page, int pageSize, string searchProperty, string searchValue)
            => _accountRepository.GetPaginateResult(page, pageSize, searchProperty, searchValue);
        public List<Account> GetAllAccounts() => _accountRepository.GetAllAccounts();
        public List<Account> GetActiveAccounts() => _accountRepository.GetActiveAccounts();
        public Account GetAccountById(Guid id) => _accountRepository.GetAccountById(id);

        public void DeleteAccount(Guid accountId) => _accountRepository.DeleteAccount(accountId);
        public void ChangeAccountStatus(Guid accountId) => _accountRepository.ChangeAccountStatus(accountId);
        public void AddAccount(Account addedAccount) => _accountRepository.AddAccount(addedAccount);
        public void UpdateAccount(Account updatedAcc) => _accountRepository.UpdateAccount(updatedAcc);

        public List<Account> SearchAccounts(string searchProperty, string searchValue) 
            => _accountRepository.SearchAccounts(searchProperty, searchValue);   
    }
}
