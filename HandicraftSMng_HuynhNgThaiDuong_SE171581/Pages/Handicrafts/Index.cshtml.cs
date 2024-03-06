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

namespace HandicraftSMng_HuynhNgThaiDuong_SE171581.Pages.Handicrafts
{
    public class IndexModel : PageModel
    {
        private readonly IHandicraftService _handicraftService;
        private readonly IHandicraftCategoryService _handicraftCategoryService;

        public IndexModel(IHandicraftService handicraftService, IHandicraftCategoryService handicraftCategoryService)
        {
            _handicraftService = handicraftService;
            _handicraftCategoryService = handicraftCategoryService;
        }

        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;
        public int Count { get; set; }
        public int PageSize { get; set; } = 4;

        public int TotalPages => (int)Math.Ceiling(decimal.Divide(Count, PageSize));

        [BindProperty(SupportsGet = true)]
        public string SearchProperty { get; set; }
        [BindProperty(SupportsGet = true)]
        public string SearchValue { get; set; }

        public IList<Handicraft> Handicraft { get;set; } = default!;
        public IList<string> CategoryName{ get;set; } = new List<string>();

        public async Task OnGetAsync()
        {
            Handicraft = _handicraftService.GetPaginateresult(CurrentPage, PageSize, SearchProperty, SearchValue);
            if (string.IsNullOrEmpty(SearchValue))
            {
                Count = _handicraftService.GetAllHandicrafts().Count;
            }
            else
            {
                Count = _handicraftService.SearchHandicrafts(SearchProperty, SearchValue).Count;
            }

            foreach (var handicraft in Handicraft)
            {
                CategoryName.Add(_handicraftCategoryService.GetCategoryName(handicraft.HandicraftCategoryId));
            }
        }

        public async Task OnPostAsync()
        {
            Handicraft = _handicraftService.GetPaginateresult(CurrentPage, PageSize, SearchProperty, SearchValue);
            if (string.IsNullOrEmpty(SearchValue))
            {
                Count = _handicraftService.GetAllHandicrafts().Count;
            }
            else
            {
                Count = _handicraftService.SearchHandicrafts(SearchProperty, SearchValue).Count;
            }

            foreach (var handicraft in Handicraft)
            {
                CategoryName.Add(_handicraftCategoryService.GetCategoryName(handicraft.HandicraftCategoryId));
            }
        }
    }
}
