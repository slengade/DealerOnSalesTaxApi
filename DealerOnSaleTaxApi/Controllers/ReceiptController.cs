using DealerOnSaleTaxApi.Models;
using DealerOnSaleTaxApi.Services;
using Microsoft.AspNetCore.Mvc;


namespace DealerOnSaleTaxApi.Controllers
{
    [ApiController]
    
    public class ReceiptController : ControllerBase
    {
       

        private readonly ILogger<ReceiptController> _logger;
        private IReceiptService receiptService;

        public ReceiptController(ILogger<ReceiptController> logger, IReceiptService receiptService)
        {
            _logger = logger;
            this.receiptService = receiptService;
        }

        [HttpPost]
        [Route("CreateReceipt")]
        public Receipt CreateReceipt(ShoppingCart shoppingCart)
        {
            try 
            {
                return receiptService.CreateReceipt(shoppingCart);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                return new Receipt();
            }
        }
    }
}