using Microsoft.AspNetCore.Mvc;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Context;
using PizzaProject.Model.Tables;

namespace PizzaProject.WebUI.Controllers
{
    public class HomeController : Controller
    {
        private readonly IDbTools<Category> _db;
        public HomeController(IDbTools<Category> db)
        {
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.GetList());
        }
        public IActionResult Eror()
        {
            return View();
        }
    }
}
