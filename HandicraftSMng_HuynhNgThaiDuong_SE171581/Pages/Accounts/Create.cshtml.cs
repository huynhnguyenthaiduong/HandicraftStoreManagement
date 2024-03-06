using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HCSBO;
using HCSService.Interfaces;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.Accounts
{
    public class CreateModel : PageModel
    {
        private readonly IAccountService _accountService;
        private readonly IRoleService _roleService;

        public CreateModel(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        public IActionResult OnGet()
        {
            ViewData["Role"] = new SelectList(_roleService.GetRoles(), "RoleId", "RoleName");
            return Page();
        }

        [BindProperty]
        public Account Account { get; set; } = default!;


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Account.Role");
            if (!ModelState.IsValid || _accountService.GetAllAccounts() == null || Account == null)
            {
                return Page();
            }

            _accountService.AddAccount(Account);

            return RedirectToPage("./Index");
        }
    }
}
