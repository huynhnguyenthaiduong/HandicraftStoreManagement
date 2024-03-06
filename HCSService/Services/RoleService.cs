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
    public class RoleService : IRoleService
    {
        private readonly IRoleRepository _roleRepository;
        public RoleService()
        {
            if (_roleRepository == null)
                _roleRepository = new RoleRepository();
        }

        public string GetRoleName(Guid roleId) => _roleRepository.GetRoleName(roleId);
        public List<Role> GetRoles() => _roleRepository.GetRoles();
    }
}
