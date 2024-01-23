using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Components
{
    public class ProductViewComponent : ViewComponent
    {
        private readonly IDbTools<Product> _db;
        public ProductViewComponent(IDbTools<Product> db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.GetList());
        }
    }
}
