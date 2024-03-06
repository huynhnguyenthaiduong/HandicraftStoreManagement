using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using HCSBO;
using HCSService.Interfaces;
using HCSService.Services;

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.HCCategory
{
    public class IndexModel : PageModel
    {
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public IndexModel(IHandicraftCategoryService handicraftCategoryService)
        {
            _handicraftCategoryService = handicraftCategoryService;
        }

        public IList<HandicraftCategory> HandicraftCategory { get;set; } = default!;

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count {  get; set; }
        public int PageSize { get; set; } = 4;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public async Task OnGetAsync()
        {
            HandicraftCategory = _handicraftCategoryService.GetPaginationResult(CurrentPage, PageSize, SearchValue);
            if (string.IsNullOrEmpty(SearchValue))
            {
                Count = _handicraftCategoryService.GetCategories().Count;
            }
            else
            {
                Count = _handicraftCategoryService.SearchCategory(SearchValue).Count;
            }
        }

        public async Task OnPostAsync()
        {
            CurrentPage = 1;
            HandicraftCategory = _handicraftCategoryService.GetPaginationResult(CurrentPage, PageSize, SearchValue);
            if (string.IsNullOrEmpty(SearchValue))
            {
                Count = _handicraftCategoryService.GetCategories().Count;
            }
            else
            {
                Count = _handicraftCategoryService.SearchCategory(SearchValue).Count;
            }
        }
    }
}
