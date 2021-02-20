using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Brand
    {
        [Key]
        public int BrandId { get; set; }
        [Required(ErrorMessage = "The name of the brand is required.")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Brand Name")]
        public string BrandName { get; set; }
        [Display(Name = "Thumbnail Url")]
        [Column(TypeName = "nvarchar(1000)")]
        public string BrandImg { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
