using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HCSBO;
using HCSService.Interfaces;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.HCCategory
{
    public class CreateModel : PageModel
    {
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public CreateModel(IHandicraftCategoryService handicraftCategoryService)
        {
            _handicraftCategoryService = handicraftCategoryService;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public HandicraftCategory HandicraftCategory { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid || _handicraftCategoryService.GetCategories() == null || HandicraftCategory == null)
            {
                return Page();
            }

            _handicraftCategoryService.AddHCCategory(HandicraftCategory);

            return RedirectToPage("./Index");
        }
    }
}
