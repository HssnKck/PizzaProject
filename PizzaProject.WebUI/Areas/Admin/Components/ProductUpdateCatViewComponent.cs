using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Components
{
    public class ProductUpdateCatViewComponent : ViewComponent
    {
        private readonly IDbTools<Category> _dbCategory;

        public ProductUpdateCatViewComponent(IDbTools<Category> dbCategory)
        {
            _dbCategory = dbCategory;

        }
        public IViewComponentResult Invoke()
        {
            return View(_dbCategory.GetList());
        }
    }
}
