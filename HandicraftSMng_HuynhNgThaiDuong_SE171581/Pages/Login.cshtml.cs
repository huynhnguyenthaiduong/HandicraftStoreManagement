using HCSBO;
using HCSBO.DTOs.Accounts;
using HCSService.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IAccountService _accountService = null;
        private readonly IRoleService _roleService = null;

        public LoginModel(IAccountService accountService, IRoleService roleService)
        {
            _accountService = accountService;
            _roleService = roleService;
        }

        [BindProperty]
        public LoginAccount Account { get; set; }

        public string ErrorMessage = String.Empty;

        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            Account account = _accountService.Login(Account.Email, Account.Password);

            if (account != null)
            {
                string roleName = _roleService.GetRoleName(account.RoleId);

                HttpContext.Session.SetString("Role", roleName);
                HttpContext.Session.SetString("Id", account.AccountId.ToString());
                HttpContext.Session.SetString("UserName", account.UserName);


                switch (roleName)
                {
                    case "Admin":
                        return RedirectToPage("/Accounts/Index");
                    case "Staff":
                        return RedirectToPage("/Handicrafts/Index");
                    case "User":
                        return RedirectToPage("/Index");
                }
                return RedirectToPage("/Index");
            }
            else
            {
                ErrorMessage = "Incorrect email or password";
                return Page();
            }
        }
    }
}
