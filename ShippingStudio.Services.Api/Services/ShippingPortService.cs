using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels.ShippingPort;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Services.Api.Services
{
    public class ShippingPortService
    {
        private readonly IShippingPortRepository shippingPortRepository;

        public ShippingPortService(IShippingPortRepository shippingPortRepository)
        {
            this.shippingPortRepository = shippingPortRepository;
        }

        public BaseResponseModel AddShippingPort(ShippingPortRequestModel shippingPort)
        {
            BaseResponseModel responseModel = new BaseResponseModel();

            if (shippingPort == null)
            {
                responseModel.Code = 1;
                responseModel.Message = "Shipping port object cannot be null, when trying to create a new port.";
                return responseModel;   
            }


            ShippingPort shippingPortEntity = new ShippingPort
            {
                Country = shippingPort.Country,
                Port = shippingPort.Port,
                IsDisabled = false
            };

            var result = shippingPortRepository.Add(shippingPortEntity);

            if (result != true)
            {
                responseModel.Code = 1;
                responseModel.Message = "An error has occured, whilst trying to create the new port.";
                return responseModel;
            }

            responseModel.Code = 0;
            responseModel.Message = "Port has been created successfully.";
            
            return responseModel;
        }

        public List<ShippingPort> GetShippingPortList()
        {
            return shippingPortRepository.GetAll(); 
        }
    }
}
