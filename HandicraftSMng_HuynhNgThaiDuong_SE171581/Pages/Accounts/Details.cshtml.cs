using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HCSBO;
using HCSService.Interfaces;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.Accounts
{
    public class DetailsModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;

        public DetailsModel(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        public Account Account { get; set; } = default!;
        public string RoleName { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (Guid.Empty.Equals(id) || _accountService.GetAllAccounts() == null)
            {
                return NotFound();
            }

            var account = _accountService.GetAccountById(id);

            if (account == null)
            {
                return NotFound();
            }
            else
            {
                Account = account;
                RoleName = _roleService.GetRoleName(account.RoleId);
            }
            return Page();
        }
    }
}
