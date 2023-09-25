using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Models.ResponseModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Interfaces.Repository
{
    public interface IFilingRepository
    {
        BaseResponseModel Add(Filing file);
        DbFilingResponseModel GetAll();
        DbFilingResponseModel Get(int id);
        DbFilingResponseModel GetbyCode(string Code);
        BaseResponseModel ChangeFileStatus(int Id);
    }
}
