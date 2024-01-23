using PizzaProject.Core.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Model.Tables
{
    public class OrderProduct : DbContextCore
    {
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Total => ProductPrice * ProductQuantity;
        public int? OrderId { get; set; }
        public virtual Order Order { get; set; }
    }
}
