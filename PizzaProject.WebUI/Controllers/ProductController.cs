using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private readonly IDbTools<Product> _dbProduct;
        private readonly IDbTools<SubCategory> _dbSubCategory;
        private readonly IDbTools<Category> _dbCategory;
        public ProductController(IDbTools<Product> dbProduct, IDbTools<SubCategory> dbSubCategory, IDbTools<Category> dbCategory)
        {
            _dbProduct = dbProduct;
            _dbSubCategory = dbSubCategory;
            _dbCategory = dbCategory;
        }
        public IActionResult Index(int id)
        {
            ViewBag.ID = _dbProduct.GetList().FirstOrDefault(x => x.SubCategoryId == id).ID;
            ViewBag.SubCategory = _dbSubCategory.GetRecord(id).SubCategoryName;
            return View(_dbProduct.GetList().Where(x => x.SubCategoryId == id).ToList());
        }
        public IActionResult AllListProduct(int id)
        {
            ViewBag.Category = _dbCategory.GetRecord(id).CategoryName;
            return View(_dbProduct.GetList().Where(x => x.CategoryId == id).ToList());
        }
        public IActionResult Detail(int id)
        {
            return View(_dbProduct.GetRecord(id));
        }
    }
}
