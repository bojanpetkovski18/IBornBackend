using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace DAL.Entities
{
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        [Required(ErrorMessage = "The name of the product is required.")]
        [Column(TypeName = "nvarchar(100)")]
        [Display(Name = "Title")]
        public string ProductName { get; set; }
        [Required(ErrorMessage = "The category of the product is required.")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        [Required(ErrorMessage = "The brand of the product is required.")]
        [Display(Name = "Brand")]
        public int BrandId { get; set; }
        [ForeignKey("BrandId")]
        public virtual Brand Brand { get; set; }
        [Column(TypeName = "nvarchar(1000)")]
        [Display(Name = "Image Url")]
        public string ProductImg { get; set; }
        [Required(ErrorMessage = "The price of the product is required.")]
        [Display(Name = "Price")]
        [Range(1, Int32.MaxValue, ErrorMessage = "The price must be over $1")]
        public double ProductPrice { get; set; }
        [Display(Name = "Discount")]
        [Range(0, 100, ErrorMessage = "The discount must be between 0 and 100 percent.")]
        public double ProductDiscount { get; set; }
        [Required(ErrorMessage = "The quantity of the product is required.")]
        [Range(0, 1000, ErrorMessage = "The quantity must be between 0 and 1000 items.")]
        public int Quantity { get; set; }
        [Required(ErrorMessage = "The rating of the product is required.")]
        [Range(1, 5, ErrorMessage = "The rating must be between 1 and 5 stars.")]
        public int Rating { get; set; }
        [Column(TypeName = "nvarchar(4000)")]
        public string Description { get; set; }
    }
}
