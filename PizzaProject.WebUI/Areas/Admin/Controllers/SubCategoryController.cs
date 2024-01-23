using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class SubCategoryController : Controller
    {
        private readonly IDbTools<SubCategory> _dbSubCategory;

        private readonly IDbTools<Category> _dbCategory;
        public SubCategoryController(IDbTools<SubCategory> SubCategory, IDbTools<Category> Category)
        {
            _dbSubCategory = SubCategory;
            _dbCategory = Category;
        }

        public IActionResult Index(int id)
        {
            ViewBag.Category = _dbCategory.GetRecord(id).CategoryName;

            return View(_dbSubCategory.GetList().Where(x => x.CategoryId == id).ToList());
        }
        public IActionResult UpdateCategory(int id)
        {
            return View(_dbSubCategory.GetRecord(id));
        }
        [HttpPost]
        public IActionResult UpdateCategory(SubCategory pc)
        {
            return _dbSubCategory.Update(pc) ? RedirectToAction("Index", new { id = _dbCategory.GetRecord(pc.CategoryId.Value).ID }) : View();
        }

        public IActionResult AddCategory()
        {
            return View(_dbCategory.GetList());
        }

        [HttpPost]
        public IActionResult AddCategory(SubCategory pc)
        {
            return _dbSubCategory.Add(pc) ? RedirectToAction("Index", new { id = _dbCategory.GetRecord(pc.CategoryId.Value).ID }) : View();
        }
        public IActionResult DeleteCategory(int id)
        {

            var pc = _dbSubCategory.GetRecord(id);
            if (_dbSubCategory.Delete(pc))
            {
                return RedirectToAction("Index", new { id = _dbCategory.GetRecord(pc.CategoryId.Value).ID });
            }
            else
            {
                ViewBag.Eror = "Kayıt Silinirken Hata Oluştu Lütfen Kategoriye Ait Ürünü Varsa Siliniz.";
                return View();
            }

        }




    }
}
