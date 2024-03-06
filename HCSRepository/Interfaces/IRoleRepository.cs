using HCSBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSRepository.Interfaces
{
    public interface IRoleRepository
    {
        public string GetRoleName(Guid roleId);
        public List<Role> GetRoles();
    }
}
