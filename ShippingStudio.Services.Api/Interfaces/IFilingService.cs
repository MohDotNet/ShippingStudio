using ShippingStudio.Domain.Models.RequestModels.Filing;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Services.Api.Interfaces
{
    public interface IFilingService
    {
        BaseResponseModel CreateFile(CreateFileRequestModel fileRequestModel);
        DbFilingResponseModel GetAllFiles();
        DbFilingResponseModel GetFile(int fileId);
        DbFilingResponseModel GetFileByCode(string code);
    }
}
