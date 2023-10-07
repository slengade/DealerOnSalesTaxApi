namespace DealerOnSaleTaxApi.Models
{
    public class ShoppingCart
    {
        public ShoppingCart()
        {
            ShoppingCartItems = new List<ShoppingCartItem>();
        }
        public ICollection<ShoppingCartItem> ShoppingCartItems { get; set; }
    }
}
