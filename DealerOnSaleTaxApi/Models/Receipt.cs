namespace DealerOnSaleTaxApi.Models
{
    public class Receipt
    {
        public Receipt()
        {
            ReceiptItems = new List<ReceiptItem>();
        }

        public decimal SalesTax { get; set; }
        public decimal OrderTotal { get; set; }
        public ICollection<ReceiptItem> ReceiptItems { get; set; }
    }
}
