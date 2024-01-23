using PizzaProject.Core.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Model.Tables
{
    public class SubCategory : DbContextCore
    {
        public string SubCategoryName { get; set; }

        public int? CategoryId { get; set; }
        public virtual Category Categories { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
