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

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.Handicrafts
{
    public class EditModel : PageModel
    {
        private readonly IHandicraftService _handicraftService;
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public EditModel(IHandicraftService handicraftService, IHandicraftCategoryService handicraftCategoryService)
        {
            _handicraftService = handicraftService;
            _handicraftCategoryService = handicraftCategoryService;
        }

        [BindProperty]
        public Handicraft Handicraft { get; set; } = default!;
        public string Category { get; set; }

        public async Task<IActionResult> OnGetAsync(Guid id)
        {
            if (Guid.Empty.Equals(id) || _handicraftService.GetAllHandicrafts() == null)
            {
                return NotFound();
            }

            var handicraft = _handicraftService.GetHandicraftById(id);
            if (handicraft == null)
            {
                return NotFound();
            }
            Handicraft = handicraft;
            ViewData["HandicraftCategory"] = new SelectList(_handicraftCategoryService.GetCategories(), "HandicraftCategoryId", "HCCategoryName");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            ModelState.Remove("Handicraft.HandicraftCategory");
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                _handicraftService.UpdateHandicraft(Handicraft);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HandicraftExists(Handicraft.HandicraftId))
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

        private bool HandicraftExists(Guid id)
        {
            return _handicraftService.GetHandicraftById(id) != null;
        }
    }
}
