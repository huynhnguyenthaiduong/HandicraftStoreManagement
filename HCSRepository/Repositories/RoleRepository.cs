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
    public class RoleRepository : IRoleRepository
    {
        public string GetRoleName(Guid roleId) => RoleDAO.Instance.GetRoleName(roleId);
        public List<Role> GetRoles() => RoleDAO.Instance.GetRoles();
    }
}
