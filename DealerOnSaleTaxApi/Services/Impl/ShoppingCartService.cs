using DealerOnSaleTaxApi.Models;

namespace DealerOnSaleTaxApi.Services
{
    public class ShoppingCartService:IShoppingCartService
    {
        public ShoppingCartService()
        {

        }

        public ShoppingCartItem ProcessShoppingCartLine (string shoppingCartLine)
        {
            var shoppingCartItem = new ShoppingCartItem(); 
            var quantityString = shoppingCartLine.Substring(0, shoppingCartLine.IndexOf(' ') + 1);
            if (Int32.TryParse(quantityString, out var quantity))
            {
                shoppingCartItem.Quantity = quantity;
                shoppingCartItem.Name = shoppingCartLine.Substring(shoppingCartLine.IndexOf(' ') + 1, shoppingCartLine.IndexOf("at") - (shoppingCartLine.IndexOf(' ') + 1));
                shoppingCartItem.IsImported = shoppingCartItem.Name.Contains("Imported");
            }
            else
            {
                return new ShoppingCartItem();
            }
            
        }
    }
}
