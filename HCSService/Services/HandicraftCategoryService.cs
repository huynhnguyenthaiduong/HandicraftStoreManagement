using HCSBO;
using HCSRepository.Interfaces;
using HCSRepository.Repositories;
using HCSService.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSService.Services
{
    public class HandicraftCategoryService : IHandicraftCategoryService
    {
        private readonly IHandicraftCategoryRepository _handicraftCategoryRepository = null;
        public HandicraftCategoryService()
        {
            if(_handicraftCategoryRepository == null)
                _handicraftCategoryRepository = new HandicraftCategoryRepository();
        }

        public List<HandicraftCategory> GetPaginationResult(int page, int pageSize, string searchValue) 
            => _handicraftCategoryRepository.GetPaginationResult(page, pageSize, searchValue);
        public Guid GetCategoryIdByName(string name) => _handicraftCategoryRepository.GetCategoryIdByName(name);
        public List<HandicraftCategory> GetCategories() => _handicraftCategoryRepository.GetCategories();
        public HandicraftCategory GetCategoryById(Guid id) => _handicraftCategoryRepository.GetCategoryById(id);
        public string GetCategoryName(Guid id) => _handicraftCategoryRepository.GetCategoryName(id);

        public List<HandicraftCategory> SearchCategory(string searchValue) => _handicraftCategoryRepository.SearchCategory(searchValue);

        public void AddHCCategory(HandicraftCategory category) => _handicraftCategoryRepository.AddHCCategory(category);
        public void UpdateHCCategory(HandicraftCategory updatedCategory) => _handicraftCategoryRepository.UpdateHCCategory(updatedCategory);
    }
}
