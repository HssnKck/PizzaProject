using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoryController : Controller
    {
        private readonly IDbTools<Category> _dbCategory;
        private readonly IDbTools<Product> _dbProduct;
        public CategoryController(IDbTools<Category> dbCategory, IDbTools<Product> dbProduct)
        {
            _dbCategory = dbCategory;
            _dbProduct = dbProduct;
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Category c)
        {
            return _dbCategory.Add(c) ? RedirectToAction("Index", "Home") : View();
        }
        public IActionResult Update(int id)
        {
            return View(_dbCategory.GetRecord(id));
        }
        [HttpPost]
        public IActionResult Update(Category c)
        {
            return _dbCategory.Update(c) ? RedirectToAction("Index", "Home") : View();
        }


        public IActionResult Delete(int id)
        {
            if (_dbCategory.Delete(_dbCategory.GetRecord(id)))
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewBag.Eror = "Kayıt Silinirken Hata Oluştu Lütfen Alt Kategorisi Varsa Siliniz.";
                return View();
            }
        }

        public IActionResult SubCategoryList(int id)
        {
            ViewBag.Category = _dbCategory.GetRecord(id).CategoryName;
            return View(_dbProduct.GetList().Where(x => x.CategoryId == id).ToList());
        }


    }
}
