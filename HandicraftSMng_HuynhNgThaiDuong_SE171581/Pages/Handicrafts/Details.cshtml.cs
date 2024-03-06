using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HCSBO;
using HCSService.Interfaces;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.Handicrafts
{
    public class DetailsModel : PageModel
    {
        private readonly IHandicraftService _handicraftService;
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public DetailsModel(IHandicraftService handicraftService, IHandicraftCategoryService handicraftCategoryService)
        {
            _handicraftService = handicraftService;
            _handicraftCategoryService = handicraftCategoryService;
        }

        public Handicraft Handicraft { get; set; } = default!; 
        public string CategoryName { get; set; }

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
            else 
            {
                Handicraft = handicraft;
                CategoryName = _handicraftCategoryService.GetCategoryName(handicraft.HandicraftCategoryId);
            }
            return Page();
        }
    }
}
