namespace PizzaProject.WebUI.Models
{
    public class BuyInBasket
    {
        public List<BuyInBasketItem> BasketItems { get; set; }
        public decimal TotalPrice { get; set; }
    }
}
