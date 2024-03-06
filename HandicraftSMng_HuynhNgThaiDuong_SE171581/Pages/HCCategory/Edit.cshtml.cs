using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HCSBO;
using HCSService.Interfaces;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.HCCategory
{
    public class EditModel : PageModel
    {
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public EditModel(IHandicraftCategoryService handicraftCategoryService)
        { 
            _handicraftCategoryService = handicraftCategoryService;
        }

        [BindProperty]
        public HandicraftCategory HandicraftCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (Guid.Empty.Equals(id) || _handicraftCategoryService.GetCategories() == null)
            {
                return NotFound();
            }

            var handicraftcategory =  _handicraftCategoryService.GetCategoryById(id);
            if (handicraftcategory == null)
            {
                return NotFound();
            }
            HandicraftCategory = handicraftcategory;
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _handicraftCategoryService.UpdateHCCategory(HandicraftCategory);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HandicraftCategoryExists(HandicraftCategory.HandicraftCategoryId))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool HandicraftCategoryExists(Guid id)
        {
          return _handicraftCategoryService.GetCategoryById(id) != null;
        }
    }
}
