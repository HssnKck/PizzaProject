using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using PizzaProject.Core.Tools;
using PizzaProject.Model.Tables;
using PizzaProject.WebUI.Dtos;
using PizzaProject.WebUI.Models;
using System.Text;

namespace PizzaProject.WebUI.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IDbTools<OrderProduct> _dbOrderProduct;
        private readonly IDbTools<Order> _dbOrder;

        public PaymentController(IDbTools<OrderProduct> dbOrderProduct, IDbTools<Order> dbOrder)
        {
            _dbOrderProduct = dbOrderProduct;
            _dbOrder = dbOrder;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(Informations info)
        {
            return RedirectToAction("Pay", info);
        }
        public async Task<IActionResult> Pay(Informations info)
        {
            return View(info);
        }
        [HttpPost]
        public async Task<IActionResult> Pay(SanalPos pos, Informations info)
        {

            try
            {
                var BasketItem = GetBasketItems();

                var jsonData = JsonConvert.SerializeObject(pos);

                var content = new StringContent(jsonData, Encoding.UTF8, "application/json");

                using (var client = new HttpClient())
                {
                    var result = await client.PostAsync("https://localhost:7130/api/Pay/GetPaid", content);
                    if (result.IsSuccessStatusCode)
                    {
                        var a = Convert.ToBoolean(await result.Content.ReadAsStringAsync());
                        if (a)
                        {
                            var OrderRecord = new Order();
                            OrderRecord.CustomerName = info.Name;
                            OrderRecord.CustomerPhone = info.Phone;
                            OrderRecord.CustomerEmail = info.Email;
                            OrderRecord.CustomerAddress = info.Address;
                            _dbOrder.Add(OrderRecord);
                            foreach (var item in BasketItem)
                            {
                                var OrderProductRecord = new OrderProduct();
                                OrderProductRecord.ProductName = item.ProductName;
                                OrderProductRecord.ProductPrice = item.ProductPrice;
                                OrderProductRecord.ProductQuantity = item.ProductQuantity;
                                OrderProductRecord.OrderId = OrderRecord.ID;
                                _dbOrderProduct.Add(OrderProductRecord);
                            }
                            return RedirectToAction("SuccessPay");
                        }
                        else
                        {
                            return RedirectToAction("Eror", "Home");
                        }
                    }
                }
            }
            catch (Exception)
            {
                return RedirectToAction("Eror", "Home");
            }
            return RedirectToAction("Eror", "Home");
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




        public IActionResult SuccessPay()
        {
            HttpContext.Session.Clear();
            return View();
        }

    }
}
