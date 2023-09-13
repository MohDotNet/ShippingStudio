using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces;
using ShippingStudio.Domain.Interfaces.Repository;
using System.Security.Cryptography.X509Certificates;

namespace ShippingStudio.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ICurrency currency;

        public CurrencyController(ICurrency currency)
        {
            this.currency = currency;
        }

        [HttpGet]
        public List<Currency> Get()
        {
            return currency.GetAll();
        }
    }
}
