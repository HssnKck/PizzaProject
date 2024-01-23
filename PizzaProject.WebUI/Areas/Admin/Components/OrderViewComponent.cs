using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Components
{
    public class OrderViewComponent : ViewComponent
    {
        private readonly IDbTools<Order> _dbOrder;

        public OrderViewComponent(IDbTools<Order> dbOrder)
        {
            _dbOrder = dbOrder;
        }
        public IViewComponentResult Invoke()
        {
            return View(_dbOrder.GetList());
        }
    }
}
