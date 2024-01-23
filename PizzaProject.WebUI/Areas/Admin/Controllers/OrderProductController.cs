using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class OrderProductController : Controller
    {
        private readonly IDbTools<OrderProduct> _dbOrderProduct;
        private readonly IDbTools<Order> _dbOrder;

        public OrderProductController(IDbTools<OrderProduct> dbOrderProduct, IDbTools<Order> dbOrder)
        {
            _dbOrderProduct = dbOrderProduct;
            _dbOrder = dbOrder;
        }

        public IActionResult Index(int id)
        {
            ViewBag.ProductName = _dbOrder.GetRecord(id).CustomerName;
            return View(_dbOrderProduct.GetList().Where(x => x.OrderId == id).ToList());
        }
    }
}
