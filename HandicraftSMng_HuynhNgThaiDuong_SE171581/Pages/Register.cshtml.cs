using HCSBO;
using HCSBO.DTOs.Accounts;
using HCSService.Interfaces;
using HCSService.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly IAccountService _accountService = null;
        private readonly IRoleService _roleService = null;

        public RegisterModel(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;

        }

        [BindProperty]
        public RegisteredAccount RegisteredAcc { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if(!ModelState.IsValid)
            {
                return Page();
            }

            Account account = _accountService.Register(RegisteredAcc);

            if (account != null)
            {
                string roleName = _roleService.GetRoleName(account.RoleId);

                HttpContext.Session.SetString("Role", roleName);
                HttpContext.Session.SetString("Id", account.AccountId.ToString());
                HttpContext.Session.SetString("UserName", account.UserName);

                return RedirectToPage("/Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
