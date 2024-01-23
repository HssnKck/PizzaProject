using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Components
{
    public class UpdateCategoryViewComponent : ViewComponent
    {
        private readonly IDbTools<Category> _db;
        public UpdateCategoryViewComponent(IDbTools<Category> db)
        {
            _db = db;
        }
        public IViewComponentResult Invoke()
        {
            return View(_db.GetList());
        }
    }
}
