using ShippingStudio.Domain.Entities;
using ShippingStudio.Domain.Interfaces.Repository;
using ShippingStudio.Domain.Models.ResponseModels;

namespace ShippingStudio.Data.Repository
{
    public class FilingRepository : IFilingRepository
    {
        private readonly ShippingDbContext shippingDbContext;

        public FilingRepository(ShippingDbContext shippingDbContext)
        {
            this.shippingDbContext = shippingDbContext;
        }

        public BaseResponseModel Add(Filing file)
        {
            BaseResponseModel response = new BaseResponseModel();

            try
            {
                Supplier? supplier = shippingDbContext.Suppliers.Where(x => x.Id == file.SupplierId).FirstOrDefault();

                if (supplier != null)
                {
                    file.Supplier = supplier;
                    shippingDbContext.Filing.Add(file);
                    shippingDbContext.SaveChanges();

                    response.Code = 0;
                    response.Message = "File has been created successfully.";
                }
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = $"The following error has been occountered : {ex.InnerException}";
            }

            return response;
        }

        public BaseResponseModel ChangeFileStatus(int FileId, int StatusId)
        {

            BaseResponseModel response = new BaseResponseModel();
            try
            {
                var _original = shippingDbContext.Filing.Where(x=> x.Id == Id).FirstOrDefault();

                if (_original != null)
                {
                    _original.FileStatus = StatusId;
                    shippingDbContext.SaveChanges();    

                    response.Code = 0;
                    response.Message = "File status has been changed";
                }
            }
            catch (Exception ex)
            {
                response.Code = 500;
                response.Message = $"Database encountered the following error : {ex.InnerException}";
            }

            return response;
        }

        public DbFilingResponseModel Get(int id)
        {
            DbFilingResponseModel responseModel = new DbFilingResponseModel();

            try
            {
                var results = shippingDbContext.Filing.Where(x => x.Id == id).FirstOrDefault();

                if (results != null)
                {
                    responseModel.Code = 0;
                    responseModel.Message = "Record found";
                    responseModel.Filing = results;

                }
                else
                {
                    responseModel.Code = 1;
                    responseModel.Message = $"Record not found : {id}";
                }
            }
            catch (Exception ex)
            {

                responseModel.Code = 10;
                responseModel.Message = $"The following error has been encountered : {ex.InnerException}";
            }

            return responseModel;
        }

        public DbFilingResponseModel GetAll()
        {
            DbFilingResponseModel responseModel = new DbFilingResponseModel();

            try
            {
                var results = shippingDbContext.Filing.ToList();

                if (results != null)
                {
                    responseModel.Code = 0;
                    responseModel.Message = "Record found";
                    responseModel.FilingList = results;

                }
                else
                {
                    responseModel.Code = 1;
                    responseModel.Message = $"No Files have been found";
                }
            }
            catch (Exception ex)
            {

                responseModel.Code = 10;
                responseModel.Message = $"The following error has been encountered : {ex.InnerException}";
            }

            return responseModel;
        }

        public DbFilingResponseModel GetbyCode(string Code)
        {
            DbFilingResponseModel responseModel = new DbFilingResponseModel();

            try
            {
                var results = shippingDbContext.Filing.Where(x => x.FileCode == Code).FirstOrDefault();

                if (results != null)
                {
                    responseModel.Code = 0;
                    responseModel.Message = "Record found";
                    responseModel.Filing = results;

                }
                else
                {
                    responseModel.Code = 1;
                    responseModel.Message = $"Record not found : {Code}";
                }
            }
            catch (Exception ex)
            {

                responseModel.Code = 10;
                responseModel.Message = $"The following error has been encountered : {ex.InnerException}";
            }

            return responseModel;
        }
    }
}
