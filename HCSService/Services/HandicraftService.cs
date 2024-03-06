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
    public class HandicraftService : IHandicraftService
    {
        private readonly IHandicraftRepository _handicraftRepository = null;
        public HandicraftService()
        {
            if(_handicraftRepository == null)
                _handicraftRepository = new HandicraftRepository();
        }

        public List<Handicraft> GetPaginateresult(int page, int pageSize, string searchProperty, string searchValue) 
            => _handicraftRepository.GetPaginateresult(page, pageSize, searchProperty, searchValue);
        public List<Handicraft> GetAllHandicrafts() => _handicraftRepository.GetAllHandicrafts();
        public List<Handicraft> GetActiveHandicrafts() => _handicraftRepository.GetActiveHandicrafts();
        public Handicraft GetHandicraftById(Guid id) => _handicraftRepository.GetHandicraftById(id);

        public List<Handicraft> SearchHandicrafts(string searchProperty, string searchValue) 
            => _handicraftRepository.SearchHandicrafts(searchProperty, searchValue);

        public void AddHandicraft(Handicraft addedHandicraft) => _handicraftRepository.AddHandicraft(addedHandicraft);
        public void UpdateHandicraft(Handicraft updatedHandicraft) => _handicraftRepository.UpdateHandicraft(updatedHandicraft);
        public void ChangeHandicraftStatus(Guid handicraftId) => _handicraftRepository.ChangeHandicraftStatus(handicraftId);
        public void DeleteHandicraft(Guid handicraftId) => _handicraftRepository.DeleteHandicraft(handicraftId);
    }
}
