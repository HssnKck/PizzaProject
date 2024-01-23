using PizzaProject.Core.Cores;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaProject.Model.Tables
{
    public class Order : DbContextCore
    {
        public string CustomerName { get; set; }
        public string CustomerPhone { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerAddress { get; set; }
        public ICollection<OrderProduct> OrderProducts { get; set; }


    }
}
