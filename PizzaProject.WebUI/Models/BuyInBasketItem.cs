namespace PizzaProject.WebUI.Models
{
    public class BuyInBasketItem
    {

        public int ID { get; set; }
        public string ProductName { get; set; }
        public decimal ProductPrice { get; set; }
        public int ProductQuantity { get; set; }
        public decimal Total => ProductPrice * ProductQuantity;
    }
}
