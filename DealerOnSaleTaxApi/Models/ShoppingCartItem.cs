namespace DealerOnSaleTaxApi.Models
{
    public class ShoppingCartItem
    {
        public ShoppingCartItem()
        {

        }

        public int Quantity { get; set; }
        public string Name { get; set; }
        public decimal RetailPrice { get; set; }
        public bool IsImported { get; set; }
        public bool IsTaxed { get; set; }
       
    }
}
