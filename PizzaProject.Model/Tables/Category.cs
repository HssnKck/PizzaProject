using PizzaProject.Core.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Model.Tables
{
    public class Category : DbContextCore
    { 
        public string CategoryName { get; set; }
       
        public ICollection<SubCategory> SubCategories { get; set; }

        public ICollection<Product> Categoriess { get; set; }
    }
}
