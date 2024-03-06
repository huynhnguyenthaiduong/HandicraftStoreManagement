using HCSBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSDAO
{
    public class HandicraftDAO
    {
        private readonly HCStoreManagementContext dbContext = null;

        private static HandicraftDAO instance = null;
        public static HandicraftDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new HandicraftDAO();
                }
                return instance;
            }
        }

        public HandicraftDAO()
        {
            if (dbContext == null)
                dbContext = new HCStoreManagementContext();
        }

        public List<Handicraft> GetPaginateresult(int page, int pageSize, string searchProperty, string searchValue)
        {
            List<Handicraft> result = new List<Handicraft>();
            if(string.IsNullOrEmpty(searchProperty) || string.IsNullOrEmpty(searchValue))
            {
                result = GetAllHandicrafts();
            }
            else
            {
                result = SearchHandicrafts(searchProperty, searchValue);
            }
            return result.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        }

        public List<Handicraft> GetAllHandicrafts()
        {
            return dbContext.Handicrafts.ToList();
        }

        public List<Handicraft> GetActiveHandicrafts()
        {
            return dbContext.Handicrafts.Where(hc => hc.Status == true).ToList();
        }

        public Handicraft GetHandicraftById(Guid id)
        {
            return dbContext.Handicrafts.FirstOrDefault(a => a.HandicraftId.Equals(id));
        }

        public List<Handicraft> SearchHandicrafts(string searchProperty, string searchValue)
        {
            List<Handicraft> result = new List<Handicraft>();
            switch (searchProperty)
            {
                case "Name":
                    result = dbContext.Handicrafts.Where(a => a.HandicraftName.Contains(searchValue)).ToList();
                    break;
                case "OriginalSource":
                    result = dbContext.Handicrafts.Where(a => a.OriginalSource.Contains(searchValue)).ToList();
                    break;
                case "Material":
                    result = dbContext.Handicrafts.Where(a => a.Material.Contains(searchValue)).ToList();
                    break;
                case "Price":
                    result = dbContext.Handicrafts.Where(a => a.Price.ToString().Contains(searchValue)).ToList();
                    break;
            }
            return result;

        }

        public void AddHandicraft(Handicraft addedHandicraft)
        {
            Handicraft handicraft = dbContext.Handicrafts
                .Where(a => a.HandicraftName.Equals(addedHandicraft.HandicraftName)).FirstOrDefault();

            if (handicraft == null)
            {
                dbContext.Handicrafts.Add(addedHandicraft);
                dbContext.SaveChanges();
            }
        }

        public void UpdateHandicraft(Handicraft updatedHandicraft)
        {
            Handicraft handicraft = dbContext.Handicrafts
                .FirstOrDefault(a => a.HandicraftId.Equals(updatedHandicraft.HandicraftId));

            if (handicraft != null)
            {
                dbContext.Entry(handicraft).CurrentValues.SetValues(updatedHandicraft);
                dbContext.SaveChanges();
            }
        }

        public void ChangeHandicraftStatus(Guid handicraftId)
        {
            Handicraft handicraft = dbContext.Handicrafts.FirstOrDefault(a => a.HandicraftId.Equals(handicraftId));

            if (handicraft != null)
            {
                dbContext.Entry(handicraft).Property<Handicraft>("Status").CurrentValue.Status = !handicraft.Status;
                dbContext.SaveChanges();
            }
        }

        public void DeleteHandicraft(Guid handicraftId)
        {
            Handicraft handicraft = dbContext.Handicrafts.FirstOrDefault(a => a.HandicraftId.Equals(handicraftId));

            if (handicraft != null)
            {
                dbContext.Remove<Handicraft>(handicraft);
                dbContext.SaveChanges();
            }
        }
    }
}