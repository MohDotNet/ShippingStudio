using ShippingStudio.Domain.Models.RequestModels.Shipping;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Services.Api.Interfaces
{

    /// <summary>
    /// Provides core functionality to the shipping cycle of an order.
    /// </summary>
    public interface IShippingService
    {

        /// <summary>
        /// Provide the ability for the capture of a packing slip.  Requires an order and orderlines to be setup already prior to calling this 
        /// method.
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        BaseResponseModel CapturePackingList(CapturePackingListRequest request);


    }
}
