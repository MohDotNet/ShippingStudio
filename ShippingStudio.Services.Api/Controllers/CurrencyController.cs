using Microsoft.AspNetCore.Mvc;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels.Curremcy;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Domain.Models.ResponseModels.Currency;
using ShippingStudio.Services.Api.Services;

namespace ShippingStudio.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly CurrencyService currencyService;

        public CurrencyController(CurrencyService currencyService)
        {
            this.currencyService = currencyService;
        }

        [HttpGet("ListCurrencies")]
        public List<Currency> Get()
        {
            return currencyService.GetAllCurrencies();
        }

        [HttpGet("GetCurrencyByCode")]
        public CurrencyResponseModel GetCurrencyByCode(string CurrencyCode)
        {
            return currencyService.GetCurrency(CurrencyCode);
        }

        [HttpPost("AddNewCurrency")]
        public BaseResponseModel AddNew([FromBody] AddCurrencyRequestModel currency) 
        {
            return currencyService.AddNew(currency);
        }

        [HttpPut("DisableCurrency")]
        public BaseResponseModel Update(int Id)
        {
            return currencyService.Update(Id);  
        }

    }
}
