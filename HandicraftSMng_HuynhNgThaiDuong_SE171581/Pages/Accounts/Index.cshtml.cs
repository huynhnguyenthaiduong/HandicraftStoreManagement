using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HCSBO;
using HCSService.Interfaces;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.Accounts
{
    public class IndexModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;

        public IndexModel(IAccountService accountServices, IRoleService roleService)
        {
            _accountService = accountServices;
            _roleService = roleService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 4;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        [BindProperty(SupportsGet = true)]
        public string SearchProperty { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public IList<Account> Account { get; set; } = default!;
        public IList<string> RoleName { get; set; } = new List<string>();

        public async Task OnGetAsync()
        {
            Account = _accountService.GetPaginateResult(CurrentPage, PageSize, SearchProperty, SearchValue);
            if (string.IsNullOrEmpty(SearchValue))
            {
                Count = _accountService.GetAllAccounts().Count;
            }
            else
            {
                Count = _accountService.SearchAccounts(SearchProperty, SearchValue).Count;
            }

            foreach (var account in Account)
            {
                RoleName.Add(_roleService.GetRoleName(account.RoleId));
            }
        }

        public async Task OnPostAsync()
        {
            Account = _accountService.GetPaginateResult(CurrentPage, PageSize, SearchProperty, SearchValue);

            if(string.IsNullOrEmpty(SearchValue))
            {
                Count = _accountService.GetAllAccounts().Count;
            }
            else
            {
                Count = _accountService.SearchAccounts(SearchProperty, SearchValue).Count;
            }

            foreach (var account in Account)
            {
                RoleName.Add(_roleService.GetRoleName(account.RoleId));
            }
        }
    }
}
