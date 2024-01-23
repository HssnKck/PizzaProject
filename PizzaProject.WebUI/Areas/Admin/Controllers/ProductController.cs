using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;
using System.ComponentModel;
using System.Linq;
using PizzaProject.WebUI.Areas.Admin.Components;
namespace PizzaProject.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductController : Controller
    {
        private readonly IDbTools<Category> _dbCategory;

        private readonly IDbTools<SubCategory> _dbSubCategory;

        private readonly IDbTools<Product> _dbProduct;


        public ProductController(IDbTools<Product> dbProduct, IDbTools<SubCategory> dbSubCategory, IDbTools<Category> dbCategory)
        {
            _dbProduct = dbProduct;
            _dbSubCategory = dbSubCategory;
            _dbCategory = dbCategory;
        }

        public IActionResult Index(int id)
        {
            ViewBag.SubCategory = _dbSubCategory.GetRecord(id).SubCategoryName;
            return View(_dbProduct.GetList().Where(x => x.SubCategoryId == id).ToList());
        }

        public IActionResult Update(int id)
        {
            return View(_dbProduct.GetRecord(id));
        }

        [HttpPost]
        public IActionResult Update(Product p, IFormFile File)
        {
            if (File != null)
            {
                var FileName = Path.GetFileName(File.FileName);
                var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", FileName);
                using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                {
                    File.CopyTo(stream);
                }
                p.ProductPicture = FileName;
            }
            if (_dbProduct.Update(p))
            {
                return RedirectToAction("Index", new { id = _dbProduct.GetRecord(p.ID).SubCategoryId });
            }
            else
            {
                ViewBag.Eror = "Lütfen Tüm Alanları Doldurduğunuzdan Emin Olun";
                return View();
            }
        }
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(Product p, IFormFile File)
        {

            if (File != null)
            {
                var FileName = Path.GetFileName(File.FileName);
                var FilePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "images", FileName);
                using (FileStream stream = new FileStream(FilePath, FileMode.Create))
                {
                    File.CopyTo(stream);
                }
                p.ProductPicture = FileName;
            }
            if (_dbProduct.Add(p))
            {
                return RedirectToAction("Index", new { id = _dbProduct.GetRecord(p.ID).SubCategoryId });
            }
            else
            {
                ViewBag.Eror = "Lütfen Tüm Alanları Doldurduğunuzdan Emin Olun";
                return View();
            }
        }
        public IActionResult Delete(int id)
        {
            var Record = _dbProduct.GetRecord(id);
            return _dbProduct.Delete(Record) ? RedirectToAction("Index", new { id = Record.SubCategoryId }) : View();
        }




    }
}
