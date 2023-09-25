using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Enums;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.RequestModels.Filing;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Services.Api.Interfaces;

namespace ShippingStudio.Services.Api.Services
{
    public class FilingService : IFilingService
    {
        private readonly IFilingRepository filingRepository;
        private readonly ISupplierRepository supplierRepository;

        public FilingService(IFilingRepository filingRepository, ISupplierRepository supplierRepository)
        {
            this.filingRepository = filingRepository;
            this.supplierRepository = supplierRepository;
        }

        public BaseResponseModel CreateFile(CreateFileRequestModel fileRequestModel)
        {
            BaseResponseModel response = new BaseResponseModel();

            if (fileRequestModel == null ) 
            {
                response.Code = 500;
                response.Message = "Request object cannot be null";
                return response;
            }

            Filing fileRecord = new Filing
            {
                FileCode = fileRequestModel.Code,
                Filename = fileRequestModel.FileDescription,
                FileStatus = (int)FileStatusEnum.New,
                SupplierId = fileRequestModel.SupplierId,
            };

            var result = filingRepository.Add(fileRecord);

            response.Code = result.Code;
            response.Message = result.Message;

            return response;
        }

        public DbFilingResponseModel GetAllFiles()
        {
            DbFilingResponseModel response = new DbFilingResponseModel();

            response.FilingList = filingRepository.GetAll().FilingList;

            if (response.FilingList.Count <= 0 )
            {
                response.Code = 500;
                response.Message = "No files currently on record.";
                return response;
            }

            response.Code = 0;
            response.Message = "File listing generated.";
            return response;
        }

        public DbFilingResponseModel GetFile(int fileId)
        {
            DbFilingResponseModel response = new DbFilingResponseModel();

            if (fileId == 0)
            {
                response.Code = 500;
                response.Message = "Invalid file id provided";
                return response;
            }

            response = filingRepository.Get(fileId);

            return response;

        }

        public DbFilingResponseModel GetFileByCode(string code)
        {
            DbFilingResponseModel response = new DbFilingResponseModel();

            if (string.IsNullOrEmpty(code))
            {
                response.Code = 500;
                response.Message = "Invalid file id provided";
                return response;
            }

            response = filingRepository.GetbyCode(code);

            return response;
        }
    }
}
