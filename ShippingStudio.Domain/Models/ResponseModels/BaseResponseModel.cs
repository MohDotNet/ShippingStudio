using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShippingStudio.Domain.Models.ResponseModels
{
    public class BaseResponseModel
    {
        public int Code { get; set; }
        public string Message { get; set; }

    }
}
