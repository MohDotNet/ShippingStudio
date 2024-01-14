using ShippingStudio.Domain.DTO;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Data.Repository
{
    public class PackingListRepository : IPackingListRepository
    {
        private readonly ShippingDbContext _context;

        public PackingListRepository(ShippingDbContext context)
        {
            _context = context;
        }


        public BaseResponseModel Add(PackingListDto packingList)
        {
            BaseResponseModel response = new BaseResponseModel();

            if (packingList is null)
            {
                response.Code = 1;
                response.Message = "Object cannot be null when trying to save.";

                return response;
            }

            try
            {

                PackingList packingListTable = new PackingList
                {
                    ArrivedDate = packingList.ArrivedDate,
                    ContainerNumber = packingList.ContainerNumber,
                    ContainerType = packingList.ContainerType,
                    CostingDate = packingList.CostingDate,
                    CostingDone = packingList.CostingDone,
                    DeliveredDate = null,
                    HasArrived = false,
                    HasDelivered = false,
                    HasDeparted = false,
                    OrderId = packingList.OrderId,
                    PackedDated = packingList.PackedDated,
                    WaybillNumber = packingList.WaybillNumber,
                    SupplierId = packingList.SupplierId,
                    ShipQuantity = packingList.ShipQuantity,
                    ShippedDate = packingList.ShippedDate,
                    QuantityCheckedIn = 0,
                };

                _context.PackingList.Add(packingListTable);
                _context.SaveChanges();

                response.Code = 0;
                response.Message = "Packing List has been saveed";
                return response;
            }
            catch (Exception ex)
            {
                response.Code = 2;
                response.Message= ex.Message;   
                return response;
                
            }
        }

        public BaseResponseModel Delete(int Id)
        {

            BaseResponseModel responseModel = new BaseResponseModel();

            var result = Get(Id);

            if (result is not null)
            {
                _context.PackingList.Remove(result);
                _context.SaveChanges();

                responseModel.Code = 0;
                responseModel.Message = $"Record has been Successfully deleted : {result.Id}";
            }
            else
            {
                responseModel.Code = 1;
                responseModel.Message = "Record either could not be found or is currently unavailable";
            }

            return responseModel;
        }

        public PackingList? Get(int id)
        {
            return GetAll().Find(x => x.Id == id);
        }

        public List<PackingList> GetAll()
        {
            return _context.PackingList.ToList();
        }

        public BaseResponseModel Save(PackingList packingList)
        {

            BaseResponseModel respoonse = new BaseResponseModel();

            if (packingList is null)
            {
                respoonse.Code = 1;
                respoonse.Message = "Input object cannot be null, when calling the save method";
            }

            var original = Get(packingList.Id);
            if (original is not null) 
            {
                
            
            }
            
            return respoonse;
        }
    }
}
