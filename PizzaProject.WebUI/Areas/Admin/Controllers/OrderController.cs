using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;
using System.ComponentModel;

namespace PizzaProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderController : Controller
    {
        private readonly IDbTools<Order> _dbOrder;
        private readonly IDbTools<OrderProduct> _dbOrderProduct;

        public OrderController(IDbTools<Order> dbOrder, IDbTools<OrderProduct> dbOrderProduct)
        {
            _dbOrder = dbOrder;
            _dbOrderProduct = dbOrderProduct;
        }

        public IActionResult Index()
        {
            return View(_dbOrder.GetList());
        }

        public IActionResult Delete(int id)
        {
            var record = _dbOrder.GetRecord(id);
            if (record != null)
            {
                foreach (var item in _dbOrderProduct.GetList().Where(x => x.OrderId == id).ToList())
                {
                    _dbOrderProduct.Delete(item);
                }
                _dbOrder.Delete(record);
                return RedirectToAction("Index");
            }
            else
            {
                return View();
            }
        }

    }
}
