using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSBO
{
    public class HandicraftCategory
    {
        public HandicraftCategory()
        {
            Handicrafts = new HashSet<Handicraft>();    
        }

        [Key]
        public Guid HandicraftCategoryId { get; set; }
        [StringLength(100)]
        [Required(ErrorMessage = "Name is required")]
        public string HCCategoryName { get; set; } = null!;

        public virtual ICollection<Handicraft> Handicrafts { get; set; } = null!;
    }
}
