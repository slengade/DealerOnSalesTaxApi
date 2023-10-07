using DealerOnSaleTaxApi.Models;

namespace DealerOnSaleTaxApi.Services
{
    public interface IReceiptService
    {
        Receipt CreateReceipt(ShoppingCart shoppingCart);
        string PrintReceipt(Receipt receipt);
    }
}
