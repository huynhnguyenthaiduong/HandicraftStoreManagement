using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using HCSBO;
using HCSService.Interfaces;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.Handicrafts
{
    public class CreateModel : PageModel
    {
        private readonly IHandicraftService _handicraftService;
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public CreateModel(IHandicraftService handicraftService, IHandicraftCategoryService handicraftCategoryService)
        {
            _handicraftService = handicraftService;
            _handicraftCategoryService = handicraftCategoryService;
        }

        public IActionResult OnGet()
        {
        ViewData["HandicraftCategory"] = new SelectList(_handicraftCategoryService.GetCategories(), "HandicraftCategoryId", "HCCategoryName");
            return Page();
        }

        [BindProperty]
        public Handicraft Handicraft { get; set; } = default!;
        

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Handicraft.HandicraftCategory");
          if (!ModelState.IsValid || _handicraftService.GetAllHandicrafts() == null || Handicraft == null)
            {
                return Page();
            }

            _handicraftService.AddHandicraft(Handicraft);

            return RedirectToPage("./Index");
        }
    }
}
