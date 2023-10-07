using DealerOnSaleTaxApi.Models;

namespace DealerOnSaleTaxApi.Services
{
    public interface IShoppingCartService
    {
        ShoppingCartItem ProcessShoppingCartLine(string shoppingCartLine);
    }
}
