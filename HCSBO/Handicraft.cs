using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HCSBO
{
    public class Handicraft
    {
        [Key]
        public Guid HandicraftId { get; set; }
        [ForeignKey("HandicraftCategoryId")]
        public Guid HandicraftCategoryId { get; set; }
        [StringLength(150)]
        [Required(ErrorMessage = "HandicraftName is required")]
        public string HandicraftName { get; set; } = null!;
        public string? Description { get; set; }
        [Required(ErrorMessage = "OriginalSource is required")]
        public string OriginalSource { get; set; } = null!;
        [Required(ErrorMessage = "Material is required")]
        public string Material { get; set; } = null!;
        [Required(ErrorMessage = "Price is required")]
        public double Price { get; set; }
        [Required(ErrorMessage = "Quantity is required")]
        public int Quantity { get; set; }
        public bool Status { get; set; }

        public virtual HandicraftCategory HandicraftCategory { get; set; } = null!;
    }
}
