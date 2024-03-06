using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSBO
{
    public class Role
    {
        public Role()
        {
            Accounts = new HashSet<Account>();
        }

        [Key]
        public Guid RoleId { get; set; }
        [StringLength(50)]
        public string RoleName { get; set; } = null!;

        public virtual ICollection<Account> Accounts { get; set; }
    }
}
