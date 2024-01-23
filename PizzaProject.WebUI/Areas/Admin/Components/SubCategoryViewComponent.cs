using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Components
{
    public class SubCategoryViewComponent : ViewComponent
    {
        private readonly IDbTools<SubCategory> _db;
        public SubCategoryViewComponent(IDbTools<SubCategory> db)
        {

            _db = db;

        }

        public IViewComponentResult Invoke()
        {
            return View(_db.GetList());
        }


    }
}
