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
    public class HandicraftRepository : IHandicraftRepository
    {
        public List<Handicraft> GetPaginateresult(int page, int pageSize, string searchProperty, string searchValue)
            => HandicraftDAO.Instance.GetPaginateresult(page, pageSize, searchProperty, searchValue);
        public List<Handicraft> GetAllHandicrafts() => HandicraftDAO.Instance.GetAllHandicrafts();
        public List<Handicraft> GetActiveHandicrafts() => HandicraftDAO.Instance.GetActiveHandicrafts();
        public Handicraft GetHandicraftById(Guid id) => HandicraftDAO.Instance.GetHandicraftById(id);

        public List<Handicraft> SearchHandicrafts(string searchProperty, string searchValue)
            => HandicraftDAO.Instance.SearchHandicrafts(searchProperty, searchValue);

        public void AddHandicraft(Handicraft addedHandicraft) => HandicraftDAO.Instance.AddHandicraft(addedHandicraft);
        public void UpdateHandicraft(Handicraft updatedHandicraft) => HandicraftDAO.Instance.UpdateHandicraft(updatedHandicraft);
        public void ChangeHandicraftStatus(Guid handicraftId) => HandicraftDAO.Instance.ChangeHandicraftStatus(handicraftId);
        public void DeleteHandicraft(Guid handicraftId) => HandicraftDAO.Instance.DeleteHandicraft(handicraftId);
    }
}
