using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaProject.Model.Tables;
using PizzaProject.WebUI.Models;

namespace PizzaProject.WebUI.Controllers
{
    public class BasketController : Controller
    {
        decimal total = 0;
        public IActionResult Index()
        {
            foreach (var item in GetBasketItems())
            {
                total += item.ProductPrice * item.ProductQuantity;
            }

            var basket = new BuyInBasket()
            {
                BasketItems = GetBasketItems(),
                TotalPrice = total
            };
            return View(basket);
        }
        public IActionResult AddToBasket(Product product, int quantity = 1)
        {
            var basketItems = GetBasketItems();
            AddProductToBasket(basketItems, product, quantity);
            SaveBasketItems(basketItems);

            return RedirectToAction("Index");
        }
        private void AddProductToBasket(List<BuyInBasketItem> basketItems, Product product, int quantity)
        {
            var record = basketItems.FirstOrDefault(x => x.ID == product.ID);

            if (record != null)
            {
                record.ProductQuantity += quantity;
            }
            else
            {
                basketItems.Add(new BuyInBasketItem { ID = product.ID, ProductName = product.ProductName, ProductPrice = Convert.ToDecimal(product.ProductPrice), ProductQuantity = quantity });
            }
        }
        public IActionResult RemoveToBasket(int id, int quantity = 1)
        {
            var BasketItems = GetBasketItems();
            RemoveProductToBasket(BasketItems, id, quantity);
            SaveBasketItems(BasketItems);

            return RedirectToAction("Index");
        }
        private void RemoveProductToBasket(List<BuyInBasketItem> basketItems, int productId, int quantity)
        {
            var existBasktItems = basketItems.FirstOrDefault(x => x.ID == productId);
            if (existBasktItems != null)
            {
                if (existBasktItems.ProductQuantity > quantity)
                {
                    existBasktItems.ProductQuantity -= quantity;
                }
                else
                {
                    basketItems.Remove(existBasktItems);
                }
            }
        }
        public IActionResult ClearBasket()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
        public void SaveBasketItems(List<BuyInBasketItem> basketItems)
        {
            var basketItemsJson = JsonConvert.SerializeObject(basketItems);
            HttpContext.Session.SetString("BasketItems", basketItemsJson);
        }
        public List<BuyInBasketItem> GetBasketItems()
        {
            var basketItems = HttpContext.Session.GetString("BasketItems");

            if (basketItems == null)
            {
                return new List<BuyInBasketItem>();
            }

            return JsonConvert.DeserializeObject<List<BuyInBasketItem>>(basketItems);
        }
    }
}
