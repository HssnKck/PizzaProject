using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Components
{
    public class SidebarCategoryViewComponent : ViewComponent
    {
        private readonly IDbTools<Category> _db;
        public SidebarCategoryViewComponent(IDbTools<Category> db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.GetList());
        }

    }
}
