namespace DealerOnSaleTaxApi.Models
{
    public class ReceiptItem
    {
        public ReceiptItem()
        {

        }

        public string Name { get; set; }
        public decimal ItemTotalPrice { get; set; }
        public int Quantity { get; set; }
        public decimal ItemIndividualPrice { get; set; }
        public decimal RetailPrice { get; set; }
        public decimal Tax { get; set; }
    }
}
