using ShippingStudio.Domain.DTO;
using ShippingStudio.Domain.Enums;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels.Shipping;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Services.Api.Interfaces;

namespace ShippingStudio.Services.Api.Services
{
    public class ShippingService : IShippingService
    {
        private readonly IPackingListRepository _packingListRepository;

        public ShippingService(IPackingListRepository packingListRepository)
        {
            _packingListRepository = packingListRepository;
        }

        public BaseResponseModel CapturePackingList(CapturePackingListRequest request)
        {
            BaseResponseModel response = new BaseResponseModel()
            {
                Code = 0,
                Message = "Packing Slip has successfully been captured"
            };

            if (request is null) 
            { 
                response.Code = 1;
                response.Message = "Request object cannot be null";
            }

            PackingListDto packingListDto = new PackingListDto()
            {
                ContainerNumber = request.ContainerNumber,
                ShipQuantity = request.ShipQuantity,
                OrderId = request.OrderId,
                OrderLineId = request.OrderLineId,
                ContainerType = request.ContainerType,
                PackedDated = request.PackedDated,
                SupplierId = request.SupplierId,
                WaybillNumber = request.WaybillNumber,
            };

            var result = _packingListRepository.Add(packingListDto);

            if (result.Code != (int)SystemCodes.success)
            {
                response.Code = result.Code;
                response.Message = result.Message;
            }

            return response;

        }
    }
}
