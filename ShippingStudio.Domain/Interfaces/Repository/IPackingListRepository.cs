using ShippingStudio.Domain.DTO;
using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Domain.Interfaces.Repository
{
    public interface IPackingListRepository
    {

        /// <summary>
        /// Create a new Packing List record
        /// </summary>
        /// <param name="packingList"></param>
        /// <returns></returns>
        BaseResponseModel Add(PackingListDto packingList);


        /// <summary>
        /// Saves changes to an existing record
        /// </summary>
        /// <param name="packingList"></param>
        /// <returns></returns>
        BaseResponseModel Save(PackingList packingList);  

        /// <summary>
        /// Completely delete a packing list.  Criteria needs to be met to delete a packinglsit.
        /// </summary>
        /// <param name="packingList"></param>
        /// <returns></returns>
        BaseResponseModel Delete(int Id);
        
        /// <summary>
        /// Load by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        PackingList? Get(int id);    
        
        /// <summary>
        /// List All PackingLists
        /// </summary>
        /// <returns></returns>
        List<PackingList> GetAll();

    }
}
