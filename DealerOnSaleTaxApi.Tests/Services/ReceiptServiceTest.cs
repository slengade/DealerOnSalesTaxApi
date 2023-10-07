using DealerOnSaleTaxApi.Models;
using DealerOnSaleTaxApi.Services;
using System.Text.Json;

namespace DealerOnSaleTaxApi.Tests.Services
{
    [TestFixture]
    public class Tests
    {
        private ReceiptService _receiptService;

        [SetUp]
        public void Setup()
        {
            _receiptService = new ReceiptService();
        }

        [Test]
        public void CreateReceiptTest()
        {
            var receiptString = @"{""shoppingCartItems"": [{ ""quantity"":1,""name"":""Imported bottle of perfume"",""retailPrice"":27.99,""isImported"":true,""isTaxed""}]}2020 -09-06T11:31:01.923395"",""TemperatureC"":-1,""Summary"":""Cold""} ";
            var shoppingCart = JsonSerializer.Deserialize<ShoppingCart>(receiptString);
      
            var receipt = _receiptService.CreateReceipt(shoppingCart);
            Assert.IsTrue(receipt.ReceiptItems.Count == 1);
        }

        [Test]
        public void PrintReceipt()
        {
            ReceiptItem receiptItem= new ReceiptItem();
            receiptItem.Quantity = 1;
            receiptItem.ItemIndividualPrice = 10;
            receiptItem.ItemTotalPrice = 10;
            receiptItem.RetailPrice = 8;
            receiptItem.Tax = 2;
            Receipt receipt = new Receipt();
            receipt.ReceiptItems.Add(receiptItem);
            receipt.OrderTotal = 10;
            receipt.SalesTax = 2;
            var receiptString = _receiptService.PrintReceipt(receipt);
            Assert.IsTrue(receiptString.Length > 1);

        }
    }
}