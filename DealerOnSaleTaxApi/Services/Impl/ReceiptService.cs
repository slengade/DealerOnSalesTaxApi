using DealerOnSaleTaxApi.Models;

namespace DealerOnSaleTaxApi.Services
{
    public class ReceiptService: IReceiptService
    {
        public Receipt CreateReceipt(ShoppingCart shoppingCart)
        {
            var receipt = new Receipt();
            decimal salesTax = 0;
            decimal orderTotal = 0;
            
            foreach (var shoppingCartItem in shoppingCart.ShoppingCartItems)
            {
                if (receipt.ReceiptItems.Any(x=>x.Name == shoppingCartItem.Name && x.RetailPrice == shoppingCartItem.RetailPrice))
                {
                    var receiptItem = receipt.ReceiptItems.Where(x => x.Name == shoppingCartItem.Name && x.RetailPrice == shoppingCartItem.RetailPrice).FirstOrDefault();
                    receiptItem.Quantity += shoppingCartItem.Quantity;
                    receiptItem.ItemTotalPrice = receiptItem.Quantity * receiptItem.ItemIndividualPrice;
                   
                    orderTotal += (shoppingCartItem.Quantity * receiptItem.ItemIndividualPrice);
                    salesTax += (shoppingCartItem.Quantity * receiptItem.Tax);
                }
                else
                {
                    var receiptItem = new ReceiptItem();
                    if (shoppingCartItem.IsTaxed)
                    {
                        var itemSalesTax = Round(shoppingCartItem.RetailPrice * .1M);
                        receiptItem.ItemIndividualPrice = shoppingCartItem.RetailPrice + itemSalesTax;
                        receiptItem.Tax = itemSalesTax;
                        salesTax += itemSalesTax;
                    }
                    else
                    {
                        receiptItem.ItemIndividualPrice = shoppingCartItem.RetailPrice;
                    }
                    if (shoppingCartItem.IsImported)
                    {
                        var itemImportTax = Round(shoppingCartItem.RetailPrice * .05M);
                        receiptItem.ItemIndividualPrice = receiptItem.ItemIndividualPrice + itemImportTax;
                        receiptItem.Tax += itemImportTax;
                        salesTax += itemImportTax;
                    }
                    
                    receiptItem.Name = shoppingCartItem.Name;
                    receiptItem.ItemTotalPrice = receiptItem.ItemIndividualPrice;
                    receiptItem.RetailPrice = shoppingCartItem.RetailPrice;
                    receiptItem.Quantity = shoppingCartItem.Quantity;
                    receiptItem.RetailPrice = shoppingCartItem.RetailPrice;
                    orderTotal += receiptItem.ItemTotalPrice;
                    receipt.ReceiptItems.Add(receiptItem);
                }
                
                
            }
            receipt.SalesTax = salesTax;
            receipt.OrderTotal = orderTotal;
            return receipt;
        }

        public string PrintReceipt(Receipt receipt)
        {
            string receiptstring = string.Empty;
            foreach(var item in receipt.ReceiptItems)
            {
                receiptstring += $"{item.Name}: {item.ItemTotalPrice} ";
                if (item.Quantity>1)
                {
                    receiptstring += $"({item.Quantity} at {item.ItemIndividualPrice})";
                }
                receiptstring += Environment.NewLine;
            }
            receiptstring += $"Sales Taxes: {receipt.SalesTax}" + Environment.NewLine;
            receiptstring += $"Total: {receipt.OrderTotal}";
            return receiptstring;
        }

        private static decimal Round(decimal value)
        {
            var ceiling = Math.Ceiling(value * 20);
            if (ceiling == 0)
            {
                return 0;
            }
            return ceiling / 20;
        }

    }
}
