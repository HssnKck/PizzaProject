using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Controllers
{
    public class SubCategoryController : Controller
    {
        private readonly IDbTools<SubCategory> _dbSubCategory;
        private readonly IDbTools<Category> _dbCategory;
        public SubCategoryController(IDbTools<SubCategory> dbSubCategory, IDbTools<Category> dbCategory)
        {
            _dbSubCategory = dbSubCategory;
            _dbCategory = dbCategory;
        }
        public IActionResult Index(int id)
        {
            ViewBag.CategoryId = id;
            ViewBag.Category = _dbCategory.GetRecord(id).CategoryName;
            return View(_dbSubCategory.GetList().Where(x => x.CategoryId == id).ToList());
        }

    }
}
