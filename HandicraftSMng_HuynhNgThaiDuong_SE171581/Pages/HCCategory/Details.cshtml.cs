using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HCSBO;
using HCSService.Interfaces;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.HCCategory
{
    public class DetailsModel : PageModel
    {
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public DetailsModel(IHandicraftCategoryService handicraftCategoryService)
        {
            _handicraftCategoryService = handicraftCategoryService;
        }

        public HandicraftCategory HandicraftCategory { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (Guid.Empty.Equals(id) || _handicraftCategoryService.GetCategories() == null)
            {
                return NotFound();
            }

            var handicraftcategory = _handicraftCategoryService.GetCategoryById(id);
            if (handicraftcategory == null)
            {
                return NotFound();
            }
            else
            {
                HandicraftCategory = handicraftcategory;
            }
            return Page();
        }
    }
}
