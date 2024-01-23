using PizzaProject.Core.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Model.Tables
{
    public class Product: DbContextCore
    {
        public string ProductName { get; set; }
        public string ProductDescription { get; set; }
        public decimal ProductPrice { get; set; }
        public string ProductPicture { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Category { get; set; }

        public int? SubCategoryId { get; set; }
        public virtual SubCategory SubCategory { get; set; }

    }
}
