using HCSBO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSDAO
{
    public class RoleDAO
    {
        private readonly HCStoreManagementContext dbContext = null;

        private static RoleDAO instance = null;
        public static RoleDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new RoleDAO();
                }
                return instance;
            }
        }

        public RoleDAO()
        {
            if (dbContext == null)
                dbContext = new HCStoreManagementContext();
        }

        public Guid GetRoleIdByName(string name)
        {
            return dbContext.Roles.Where(r => r.RoleName.Equals(name)).Select(r => r.RoleId).FirstOrDefault();
        }

        public List<Role> GetRoles()
        {
            return dbContext.Roles.ToList();
        }

        public string GetRoleName(Guid roleId)
        {
            return dbContext.Roles.Where(r => r.RoleId.Equals(roleId)).Select(r => r.RoleName).FirstOrDefault();
        }
    }
}
