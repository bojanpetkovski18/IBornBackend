using System;
using System.Collections.Generic;
using System.Text;

namespace DBL.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int BrandId { get; set; }
        public string ProductImg { get; set; }
        public double ProductPrice { get; set; }
        public double ProductDiscount { get; set; }
        public int Quantity { get; set; }
        public int Rating { get; set; }
        public string Description { get; set; }
    }
}
