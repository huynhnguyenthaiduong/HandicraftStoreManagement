using HCSBO;
using HCSDAO;
using HCSRepository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSRepository.Repositories
{
    public class HandicraftCategoryRepository : IHandicraftCategoryRepository
    {
        public List<HandicraftCategory> GetPaginationResult(int page, int pageSize, string searchValue)
            => HandicraftCategoryDAO.Instance.GetPaginationResult(page, pageSize, searchValue);
        public Guid GetCategoryIdByName(string name) => HandicraftCategoryDAO.Instance.GetCategoryIdByName(name);
        public List<HandicraftCategory> GetCategories() => HandicraftCategoryDAO.Instance.GetCategories();
        public HandicraftCategory GetCategoryById(Guid id) => HandicraftCategoryDAO.Instance.GetCategoryById(id);
        public string GetCategoryName(Guid id) => HandicraftCategoryDAO.Instance.GetCategoryName(id);

        public List<HandicraftCategory> SearchCategory(string searchValue) => HandicraftCategoryDAO.Instance.SearchCategory(searchValue);

        public void AddHCCategory(HandicraftCategory category) => HandicraftCategoryDAO.Instance.AddHCCategory(category);
        public void UpdateHCCategory(HandicraftCategory updatedCategory) => HandicraftCategoryDAO.Instance.UpdateHCCategory(updatedCategory);
    }
}
