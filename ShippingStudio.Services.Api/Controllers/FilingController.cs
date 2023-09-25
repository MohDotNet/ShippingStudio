using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ShippingStudio.Domain.Models.RequestModels.Filing;
using ShippingStudio.Domain.Models.ResponseModels;
using ShippingStudio.Services.Api.Interfaces;

namespace ShippingStudio.Services.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilingController : ControllerBase
    {
        private readonly IFilingService filingService;

        public FilingController(IFilingService filingService)
        {
            this.filingService = filingService;
        }

        [HttpPost("Create")]
        public BaseResponseModel CreateFile(CreateFileRequestModel fileRequestModel)
        {
            return filingService.CreateFile(fileRequestModel);
        }

        [HttpGet("GetAll")]
        public DbFilingResponseModel GetAllFiles()
        {
            return filingService.GetAllFiles();
        }

        [HttpGet("GetFileByid")]
        public DbFilingResponseModel GetFile(int fileId)
        {
            return filingService.GetFile(fileId);   
        }

        [HttpGet("GetFileByCode")]
        public DbFilingResponseModel GetFileByCode(string code)
        {
            return filingService.GetFileByCode(code);
        }
    }
}
