using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Models.RequestModels.ShippingPort;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Services.Api.Services;

namespace ShippingStudio.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShippingPortController : ControllerBase
    {
        private readonly ShippingPortService shippingPortService;

        public ShippingPortController(ShippingPortService shippingPortService)
        {
            this.shippingPortService = shippingPortService;
        }

        [HttpPost("CreateNew")]
        public BaseResponseModel CreateNew([FromBody] ShippingPortRequestModel shippingPortRequestModel)
        {
            return shippingPortService.AddShippingPort(shippingPortRequestModel);
        }

        [HttpGet]
        public List<ShippingPort> GetShippingPorts()
        {
            return shippingPortService.GetShippingPortList();
        }
    }
}
