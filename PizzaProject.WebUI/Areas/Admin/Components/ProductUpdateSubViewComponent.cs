using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Components
{
    public class ProductUpdateSubViewComponent : ViewComponent
    {
        private readonly IDbTools<SubCategory> _dbSubCategory;
        public ProductUpdateSubViewComponent(IDbTools<SubCategory> dbSubCategory)
        {
            _dbSubCategory = dbSubCategory;
            
        }
        public IViewComponentResult Invoke()
        {
            return View(_dbSubCategory.GetList());
        }
    }
}
