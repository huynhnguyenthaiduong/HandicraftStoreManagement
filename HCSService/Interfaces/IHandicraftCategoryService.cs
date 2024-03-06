using HCSBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSService.Interfaces
{
    public interface IHandicraftCategoryService
    {
        public List<HandicraftCategory> GetPaginationResult(int page, int pageSize, string searchValue);
        public Guid GetCategoryIdByName(string name);
        public List<HandicraftCategory> GetCategories();
        public HandicraftCategory GetCategoryById(Guid id);
        public string GetCategoryName(Guid id);

        public List<HandicraftCategory> SearchCategory(string searchValue);

        public void AddHCCategory(HandicraftCategory category);
        public void UpdateHCCategory(HandicraftCategory updatedCategory);
    }
}
