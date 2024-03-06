using HCSBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace HCSDAO
{
    public class HandicraftCategoryDAO
    {
        private readonly HCStoreManagementContext dbContext = null;

        private static HandicraftCategoryDAO instance = null;
        public static HandicraftCategoryDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HandicraftCategoryDAO();
                }
                return instance;
            }
        }

        public HandicraftCategoryDAO()
        {
            if (dbContext == null)
                dbContext = new HCStoreManagementContext();
        }

        public List<HandicraftCategory> GetPaginationResult(int page, int pageSize, string searchValue)
        {
            List<HandicraftCategory> result = new List<HandicraftCategory>();
            if (string.IsNullOrEmpty(searchValue))
            {
                result = GetCategories();
            }
            else
            {
                result = SearchCategory(searchValue);
            }
            return result.Skip((page - 1)  * pageSize).Take(pageSize).ToList();   
        }

        public Guid GetCategoryIdByName(string name)
        {
            return dbContext.HandicraftCategories.Where(r => r.HCCategoryName.Equals(name)).Select(r => r.HandicraftCategoryId).FirstOrDefault();
        }

        public List<HandicraftCategory> GetCategories()
        {
            return dbContext.HandicraftCategories.ToList();
        }

        public HandicraftCategory GetCategoryById(Guid id)
        {
            return dbContext.HandicraftCategories.FirstOrDefault(hcc => hcc.HandicraftCategoryId.Equals(id));
        }

        public string GetCategoryName(Guid id)
        {
            return dbContext.HandicraftCategories.Where(r => r.HandicraftCategoryId.Equals(id)).Select(r => r.HCCategoryName).FirstOrDefault();
        }
        public List<HandicraftCategory> SearchCategory(string searchValue)
        {
            return dbContext.HandicraftCategories.Where(r => r.HCCategoryName.Contains(searchValue)).ToList();
        }

        public void AddHCCategory(HandicraftCategory category)
        {
            HandicraftCategory handicraftCategory = dbContext.HandicraftCategories.
                FirstOrDefault(x => x.HandicraftCategoryId.Equals(category.HandicraftCategoryId));

            if(handicraftCategory == null)
            {
                dbContext.HandicraftCategories.Add(category);
                dbContext.SaveChanges();
            }
        }

        public void UpdateHCCategory(HandicraftCategory updatedCategory)
        {
            HandicraftCategory handicraftCategory = dbContext.HandicraftCategories.
                FirstOrDefault(x => x.HandicraftCategoryId.Equals(updatedCategory.HandicraftCategoryId));

            if (handicraftCategory != null)
            {
                dbContext.Entry(handicraftCategory).CurrentValues.SetValues(updatedCategory);
                dbContext.SaveChanges();
            }
        }
    }
}
