using HCSBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSService.Interfaces
{
    public interface IHandicraftService
    {
        public List<Handicraft> GetPaginateresult(int page, int pageSize, string searchProperty, string searchValue);
        public List<Handicraft> GetAllHandicrafts();
        public List<Handicraft> GetActiveHandicrafts();
        public Handicraft GetHandicraftById(Guid id);

        public List<Handicraft> SearchHandicrafts(string searchProperty, string searchValue);

        public void AddHandicraft(Handicraft addedHandicraft);
        public void UpdateHandicraft(Handicraft updatedHandicraft);
        public void ChangeHandicraftStatus(Guid handicraftId);
        public void DeleteHandicraft(Guid handicraftId);
    }
}
