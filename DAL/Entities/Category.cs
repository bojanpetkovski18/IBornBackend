using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "The category name is required.")]
        [Column(TypeName = "nvarchar(100)")]
        public string CategoryName { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
